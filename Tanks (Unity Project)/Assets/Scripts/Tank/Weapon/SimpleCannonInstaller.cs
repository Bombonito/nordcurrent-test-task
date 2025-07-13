using UnityEngine;
using UnityEngine.InputSystem;
using Utilities;
using Zenject;

namespace Tank.Weapon
{
    public class SimpleCannonInstaller : MonoInstaller
    {
        [SerializeField] private InputActionReference _fireAction;
        [SerializeField] private BaseSpawner _projectileSpawner;
        [SerializeField] private GameObject _ignoreTankCollisions;
        
        public override void InstallBindings()
        {
            var simpleGun = new SimpleCannon(_fireAction, _projectileSpawner, _ignoreTankCollisions);
            Container.BindInterfacesAndSelfTo<SimpleCannon>().FromInstance(simpleGun).AsSingle().NonLazy();
            Container.QueueForInject(simpleGun);
        }
    }
}