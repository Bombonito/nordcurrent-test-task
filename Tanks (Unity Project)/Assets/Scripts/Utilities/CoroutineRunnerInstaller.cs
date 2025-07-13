using UnityEngine;
using Zenject;

namespace Utilities
{
    public class CoroutineRunnerInstaller : MonoInstaller
    {
        [SerializeField] private CoroutineRunner _coroutineRunner;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<CoroutineRunner>().FromInstance(_coroutineRunner).AsSingle().NonLazy();
        }
    }
}