using Tank.Locomotion.Settings;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace Tank.Locomotion.Strategies.Player
{
    public class PlayerTankLocomotionStrategy : ITankLocomotionStrategy
    {
        private PlayerLocomotionStrategyData _data;
        private NavMeshAgent Tank => _data.Tank;
        private LocomotionSettings Settings => _data.LocomotionSettings;
        private InputActionReference Move => _data.Move;

        public PlayerTankLocomotionStrategy(PlayerLocomotionStrategyData data)
        {
            _data = data;
            Move.action.Enable();
        }

        public void Tick()
        {
            var move = Move.action.ReadValue<Vector2>();

            var forwardDelta = move.y * Settings.MoveSpeedUnitsPerSecond * Time.deltaTime;
            var rotationDelta = move.x * Settings.RotateSpeedEulerPerSecond * Time.deltaTime * Mathf.Sign(forwardDelta);
            var forwardDeltaInGlobalSpace = Tank.transform.forward * forwardDelta;

            Tank.Move(forwardDeltaInGlobalSpace);
            Tank.transform.Rotate(Vector3.up, rotationDelta);
        }

        public void FixedTick()
        {
        }
    }
}