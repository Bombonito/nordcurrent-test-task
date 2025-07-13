using System;
using Health;
using Tank.Locomotion.Strategies;
using Tank.Locomotion.Strategies.SimpleBot;
using Zenject;

namespace Tank.Installer
{
    public class ChangeBotDirectionAfterDamageDealt : IInitializable, ILateDisposable
    {
        [Inject] public ITankLocomotion TankLocomotion { get; }
        public IDamageDealer DamageDealer { get; private set; }

        public ChangeBotDirectionAfterDamageDealt(IDamageDealer damageDealer)
        {
            DamageDealer = damageDealer;
        }

        public void Initialize()
        {
            DamageDealer.DamageDealt += OnDamageDealt;
        }

        private void OnDamageDealt()
        {
            if (TankLocomotion.LocomotionStrategy is SimpleBotTankLocomotionStrategy simpleBotTankLocomotionStrategy)
            {
                simpleBotTankLocomotionStrategy.ChangeDirection();
            }
        }


        public void LateDispose()
        {
            DamageDealer.DamageDealt -= OnDamageDealt;
        }
    }
}