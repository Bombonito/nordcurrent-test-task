using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Utilities;
using Zenject;

namespace Tank.Weapon
{
    public class SimpleCannon : IClassicWeapon, Zenject.ILateDisposable
    {
        public GameObject IgnoreTankCollisions { get; private set; }
        public InputActionReference FireInput { get; private set; }
        public BaseSpawner ProjectileSpawner { get; private set; }

        public SimpleCannon(InputActionReference fireInput, BaseSpawner projectileSpawner, GameObject ignoreTankCollisions = null)
        {
            FireInput = fireInput;
            ProjectileSpawner = projectileSpawner;
            IgnoreTankCollisions = ignoreTankCollisions;
            
            FireInput.action.started += OnFireInputStart;
            FireInput.action.Enable();
        }

        private void OnFireInputStart(InputAction.CallbackContext context)
        {
            Fire();
        }

        public void Fire()
        {
            var projectile = ProjectileSpawner.SpawnDisabledWithResult();
            projectile.IgnoreCollisions(IgnoreTankCollisions);
            projectile.SetActive(true);
        }

        public void LateDispose()
        {
            FireInput.action.started -= OnFireInputStart;
        }
    }
}