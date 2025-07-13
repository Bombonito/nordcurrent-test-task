using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using Utilities;

namespace Gamemode
{
    // This is a quick monolyth just for demo. Scalable modular systems are locomotion/weapon/health/save system.
    public class GameModeDemo : MonoBehaviour
    {
        [SerializeField] private BaseSpawner[] _spawners;
        [SerializeField] private BaseSpawner _initialPlayerSpawner;
        [Header("Prefabs")] [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private GameObject _botPrefab;
        [SerializeField] private int _maxBotCount;

        private GameObject _currentPlayer;
        private List<GameObject> _currentBots = new List<GameObject>();

        private Coroutine _coroutinePlayerRespawn = null;
        private int _pendingBotSpawn = 0;

        public bool IsPlayerAlive => _currentPlayer is not null && _currentPlayer;

        public int MaxBotCount
        {
            get => _maxBotCount;
            set => _maxBotCount = value;
        }

        public IReadOnlyList<GameObject> CurrentBots => _currentBots;
        public GameObject CurrentPlayer => _currentPlayer;
        public GameObject PlayerPrefab => _playerPrefab;
        public GameObject BotPrefab => _botPrefab;

        public void RegisterCustomSpawnedBot(GameObject customBot)
        {
            _currentBots.Add(customBot);
        }

        public void RegisterCustomSpawnedPlayer(GameObject customPlayer)
        {
            _currentPlayer = customPlayer;
        }

        public void Clear()
        {
            if (IsPlayerAlive)
                Destroy(_currentPlayer.gameObject);
            foreach (var bot in _currentBots)
            {
                Destroy(bot.gameObject);
            }
            StopAllCoroutines();
            _pendingBotSpawn = 0;
        }

        private void Start()
        {
            var player = _initialPlayerSpawner.SpawnPrefabWithResult(_playerPrefab);
            _currentPlayer = player;
            foreach (var spawner in _spawners.Except(new[] { _initialPlayerSpawner }))
            {
                if (_currentBots.Count >= _maxBotCount)
                    break;
                var bot = spawner.SpawnPrefabWithResult(_botPrefab);
                _currentBots.Add(bot);
            }
        }

        private void Update()
        {
            if (Time.timeScale == 0)
                return;
            
            var mustRespawnPlayer = IsPlayerAlive == false && _coroutinePlayerRespawn is null;
            _currentBots.RemoveAll(x => x is null || x == false);
            var amountToRespawnBots = _maxBotCount - _currentBots.Count - _pendingBotSpawn;

            if (mustRespawnPlayer)
            {
                _coroutinePlayerRespawn = StartCoroutine(RespawnPlayerCoroutine(1f));
            }

            for (int i = 0; i < amountToRespawnBots; i++)
            {
                StartCoroutine(RespawnBotCoroutine(1f));
            }
        }

        private IEnumerator RespawnPlayerCoroutine(float cooldownSeconds)
        {
            while (IsPlayerAlive == false)
            {
                yield return new WaitForSeconds(cooldownSeconds);
                TrySpawnPrefabInRandomSpawner(_playerPrefab, _spawners, out _currentPlayer);
            }
            
            _coroutinePlayerRespawn = null;
        }

        private IEnumerator RespawnBotCoroutine(float cooldownSeconds)
        {
            _pendingBotSpawn++;
            GameObject instance = null;
            while (instance is null || instance == false)
            {
                yield return new WaitForSeconds(cooldownSeconds);
                TrySpawnPrefabInRandomSpawner(_botPrefab, _spawners, out instance);
            }

            _pendingBotSpawn--;
            _currentBots.Add(instance);
        }

        private bool TrySpawnPrefabInRandomSpawner(GameObject prefab, BaseSpawner[] spawners, out GameObject instance)
        {
            var shuffledSpawners = ((BaseSpawner[])spawners.Clone());
            shuffledSpawners.Shuffle();
            for (int i = 0; i < shuffledSpawners.Length; i++)
            {
                if (shuffledSpawners[i].CanSpawn(prefab))
                {
                    instance = shuffledSpawners[i].SpawnPrefabWithResult(prefab);
                    return true;
                }
            }

            instance = null;
            return false;
        }
    }
}