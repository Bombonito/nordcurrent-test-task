using Tank.Locomotion.Misc;
using Tank.Locomotion.Settings;
using UnityEngine.AI;

namespace Tank.Locomotion.Strategies.SimpleBot
{
    public class SimpleBotLocomotionStrategyData
    {
        public NavMeshAgent Tank;
        public LocomotionSettings LocomotionSettings;
        public BotObstacleHandler BotObstacleHandler;
        public float CooldownSecondsChangeDirection;

        public SimpleBotLocomotionStrategyData(NavMeshAgent tank, LocomotionSettings locomotionSettings, BotObstacleHandler botObstacleHandler, float cooldownSecondsChangeDirection)
        {
            Tank = tank;
            LocomotionSettings = locomotionSettings;
            BotObstacleHandler = botObstacleHandler;
            CooldownSecondsChangeDirection = cooldownSecondsChangeDirection;
        }
    }
}