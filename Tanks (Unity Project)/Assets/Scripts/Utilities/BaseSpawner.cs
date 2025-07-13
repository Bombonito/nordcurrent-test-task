using UnityEngine;

namespace Utilities
{
    public abstract class BaseSpawner : MonoBehaviour
    {
        public abstract void Spawn();
        public abstract GameObject SpawnWithResult();
        public abstract void SpawnPrefab(GameObject prefab);
        public abstract GameObject SpawnPrefabWithResult(GameObject prefab);
        public abstract GameObject SpawnDisabledWithResult();

        public abstract bool CanSpawn();
        public abstract bool CanSpawn(GameObject prefab);
    }
}