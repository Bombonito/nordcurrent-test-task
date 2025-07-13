using Save_System.Adapters;
using UnityEngine;
using Zenject;

namespace Save_System.Installers
{
    public class TankSaveAdapterInstaller : MonoInstaller
    {
        [SerializeField] private TankSaveAdapter _saveAdapter;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<TankSaveAdapter>().FromInstance(_saveAdapter).AsSingle().NonLazy();
        }
    }
}