using Zenject;

namespace Save_System
{
    public class SaveSystemInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SaveSystem>().FromNew().AsSingle().NonLazy();
        }
    }
}