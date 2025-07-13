using System;
using UnityEngine;

namespace Utilities
{
    public class IgnoreCollision : MonoBehaviour
    {
        [Header("Will ignore all collisions between child colliders of root")]
        [SerializeField] private GameObject _root;

        private void Awake()
        {
            _root.IgnoreCollisions();
        }
    }
}