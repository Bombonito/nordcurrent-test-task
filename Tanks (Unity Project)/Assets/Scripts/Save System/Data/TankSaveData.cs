using System;
using Save_System.Types;
using UnityEngine;

namespace Save_System.Data
{
    [Serializable]
    public class TankSaveData
    {
        [SerializeField] private EntityType _entityType;
        [SerializeField] private Vector3 _position;
        [SerializeField] private Quaternion _rotation;

        public EntityType EntityType => _entityType;
        public Vector3 Position => _position;
        public Quaternion Rotation => _rotation;

        public TankSaveData(EntityType entityType, Vector3 position, Quaternion rotation)
        {
            _entityType = entityType;
            _position = position;
            _rotation = rotation;
        }
    }
}