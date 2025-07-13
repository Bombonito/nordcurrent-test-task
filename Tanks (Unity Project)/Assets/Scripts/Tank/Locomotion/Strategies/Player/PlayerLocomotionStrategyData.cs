using Tank.Locomotion.Settings;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace Tank.Locomotion.Strategies.Player
{
    public class PlayerLocomotionStrategyData
    {
        public NavMeshAgent Tank;
        public LocomotionSettings LocomotionSettings;
        public InputActionReference Move;

        public PlayerLocomotionStrategyData(NavMeshAgent tank, LocomotionSettings locomotionSettings, InputActionReference move)
        {
            Tank = tank;
            LocomotionSettings = locomotionSettings;
            Move = move;
        }
    }
}