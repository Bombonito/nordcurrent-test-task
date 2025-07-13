using System;
using UnityEngine;
using Zenject;

namespace Utilities
{
    public class SimpleSpawner : BaseSpawner
    {
        [SerializeField] private GameObject _prefab;

        [Inject] public DiContainer DiContainer { get; }

        public override void Spawn() => SpawnWithResult();

        public override GameObject SpawnWithResult()
        {
            return DiContainer.InstantiatePrefab(_prefab, transform.position, transform.rotation, null);
        }

        public override void SpawnPrefab(GameObject prefab) => SpawnPrefabWithResult(prefab);

        public override GameObject SpawnPrefabWithResult(GameObject prefab)
        {
            return DiContainer.InstantiatePrefab(prefab, transform.position, transform.rotation, null);
        }

        public override GameObject SpawnDisabledWithResult()
        {
            var state = _prefab.activeSelf;
            _prefab.SetActive(false);
            var instance = DiContainer.InstantiatePrefab(_prefab, transform.position, transform.rotation, null);
            _prefab.SetActive(state);
            return instance;
        }

        public override bool CanSpawn() => true;

        public override bool CanSpawn(GameObject prefab) => true;
    }
}