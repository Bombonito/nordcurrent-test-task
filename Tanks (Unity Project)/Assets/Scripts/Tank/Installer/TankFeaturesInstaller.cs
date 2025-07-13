using Health;
using UnityEngine;
using Zenject;

namespace Tank.Installer
{
    public class TankFeaturesInstaller : MonoInstaller
    {
        [SerializeField] private bool _changeDirectionOnDamageDealt;
        [SerializeField] private TeamDamageDealerBehaviour _botCollisionDamageDealer;

        public override void InstallBindings()
        {
            if (_changeDirectionOnDamageDealt)
            {
                Container.BindInterfacesAndSelfTo<ChangeBotDirectionAfterDamageDealt>()
                    .FromNew()
                    .AsSingle()
                    .WithArguments(_botCollisionDamageDealer)
                    .NonLazy();
            }
        }
    }
}