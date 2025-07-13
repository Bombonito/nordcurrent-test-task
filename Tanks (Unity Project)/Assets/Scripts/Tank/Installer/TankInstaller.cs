using Health;
using Tank.Locomotion.Misc;
using Tank.Locomotion.Settings;
using Tank.Locomotion.Strategies;
using Tank.Locomotion.Strategies.Player;
using Tank.Locomotion.Strategies.SimpleBot;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using Zenject;

namespace Tank.Installer
{
    public class TankInstaller : MonoInstaller
    {
        public const float COOLDOWN_SECONDS_CHANGE_DIRECTION_BOT = 2f;
        public const int DEFAULT_HP = 1;
        
        [SerializeField] private NavMeshAgent _tank;
        [SerializeField] private LocomotionSettings _defaultSettings;
        [SerializeField] private InputActionReference _move;
        [SerializeField] private bool _isPlayer;
        [Header("Optional")] 
        [SerializeField] private BotObstacleHandler _botObstacleHandler;

        [Inject] public SignalBus SignalBus { get; }

        public override void InstallBindings()
        {
            Container.DefaultParent = null;
            
            Container.BindInterfacesAndSelfTo<NavMeshAgent>().FromInstance(_tank).AsSingle().NonLazy();
            
            var locomotion = Container.Instantiate<SimpleLocomotion>();
            Container.BindInterfacesAndSelfTo<ITankLocomotion>().FromInstance(locomotion).AsSingle().NonLazy();
            
            ITankLocomotionStrategy locomotionStrategy = _isPlayer
                ? new PlayerTankLocomotionStrategy(new PlayerLocomotionStrategyData(_tank, _defaultSettings, _move))
                : new SimpleBotTankLocomotionStrategy(new SimpleBotLocomotionStrategyData(_tank, _defaultSettings, _botObstacleHandler, COOLDOWN_SECONDS_CHANGE_DIRECTION_BOT));
            locomotion.Set(locomotionStrategy);

            IHealth health = new SimpleHealth(DEFAULT_HP, DEFAULT_HP);
            Container.BindInterfacesAndSelfTo<IHealth>().FromInstance(health).AsSingle().NonLazy();
        }
    }
}