using System;
using UnityEngine;

namespace Utilities.Presence
{
    public class PresenceBasedSpawner : BaseSpawner
    {
        [SerializeField] private BaseSpawner _simpleSpawner;
        [SerializeField] private PresenceDetector _presenceDetector;

        public override void Spawn() => _simpleSpawner.Spawn();
        public override GameObject SpawnWithResult() => _simpleSpawner.SpawnWithResult();
        public override void SpawnPrefab(GameObject prefab) => _simpleSpawner.SpawnPrefab(prefab);
        public override GameObject SpawnPrefabWithResult(GameObject prefab) => _simpleSpawner.SpawnPrefabWithResult(prefab);
        public override GameObject SpawnDisabledWithResult() => _simpleSpawner.SpawnDisabledWithResult();

        public override bool CanSpawn()
        {
            return _presenceDetector.PresenceCount == 0;
        }

        public override bool CanSpawn(GameObject prefab)
        {
            return _presenceDetector.PresenceCount == 0;
        }
        
        #if UNITY_EDITOR
        private void Reset()
        {
            TryGetComponent<BaseSpawner>(out _simpleSpawner);
            TryGetComponent<PresenceDetector>(out _presenceDetector);
        }
#endif
    }
}