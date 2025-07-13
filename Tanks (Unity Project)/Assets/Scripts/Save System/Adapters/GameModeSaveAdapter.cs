using System;
using System.Collections;
using System.Collections.Generic;
using Gamemode;
using Save_System.Data;
using Save_System.Types;
using UnityEngine;
using Utilities;
using Zenject;

namespace Save_System.Adapters
{
    [RequireComponent(typeof(GameModeDemo))]
    public class GameModeSaveAdapter : MonoBehaviour, ISaveAdapter<GameModeSaveData>
    {
        [SerializeField] private GameModeDemo _gameMode;
        [SerializeField] private SimpleSpawner _saveSpawner;
        
        [Inject] public ISaveObserver<GameModeSaveAdapter> SaveObserver { get; }

        public void Start()
        {
            SaveObserver.Add(this);
        }

        private void OnDestroy()
        {
            SaveObserver?.Remove(this);
        }

        public GameModeSaveData Extract()
        {
            var _tankSaveDatas = new List<TankSaveData>();

            if (_gameMode.IsPlayerAlive)
            {
                var saveAdapter = _gameMode.CurrentPlayer.GetComponent<GameObjectContext>().Container.Resolve<ISaveAdapter<TankSaveData>>();
                _tankSaveDatas.Add(saveAdapter.Extract());
            }
            foreach (var botGO in _gameMode.CurrentBots)
            {
                var saveAdapter = botGO.GetComponent<GameObjectContext>().Container.Resolve<ISaveAdapter<TankSaveData>>();
                _tankSaveDatas.Add(saveAdapter.Extract());
            }
            
            return new GameModeSaveData(_gameMode.MaxBotCount, _tankSaveDatas);
        }

        public IEnumerator ApplyCoroutine(GameModeSaveData saveData)
        {
            _gameMode.Clear();
            _gameMode.MaxBotCount = saveData.MaxBotCount;

            foreach (var tankSaveData in saveData.Tanks)
            {
                var prefab = tankSaveData.EntityType switch
                {
                    EntityType.BotTank => _gameMode.BotPrefab,
                    EntityType.PlayerTank => _gameMode.PlayerPrefab,
                    _ => null
                };
                if (prefab is null || prefab == false)
                    continue;

                var instance = _saveSpawner.SpawnPrefabWithResult(prefab);
                var saveAdapter = instance.GetComponent<GameObjectContext>().Container.Resolve<TankSaveAdapter>();
                yield return saveAdapter.ApplyCoroutine(tankSaveData);

                switch (tankSaveData.EntityType)
                {
                    case EntityType.BotTank:
                        _gameMode.RegisterCustomSpawnedBot(instance);
                        break;
                    case EntityType.PlayerTank:
                        _gameMode.RegisterCustomSpawnedPlayer(instance);
                        break;
                    default:
                        continue;
                }
            }

            yield return null;
        }
        
#if UNITY_EDITOR
        private void Reset()
        {
            _gameMode = GetComponent<GameModeDemo>();
        }
#endif
    }
}