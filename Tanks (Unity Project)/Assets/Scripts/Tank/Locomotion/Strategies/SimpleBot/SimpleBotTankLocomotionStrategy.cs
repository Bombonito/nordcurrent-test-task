using Tank.Locomotion.Misc;
using Tank.Locomotion.Settings;
using UnityEngine;
using UnityEngine.AI;

namespace Tank.Locomotion.Strategies.SimpleBot
{
    // This better be a StateMachine with different states
    public class SimpleBotTankLocomotionStrategy : ITankLocomotionStrategy, IBotLocomotionApi
    {
        private enum BotLocomotionState
        {
            None = 0,
            Rotation,
            Moving
        }

        private SimpleBotLocomotionStrategyData _data;
        private NavMeshAgent Tank => _data.Tank;
        private LocomotionSettings LocomotionSettings => _data.LocomotionSettings;
        private BotObstacleHandler BotObstacleHandler => _data.BotObstacleHandler;

        private Quaternion _desiredRotation;
        private BotLocomotionState _locomotionState = BotLocomotionState.None;

        private float _timeSinceLastDirectionChange = 0f;
        
        public SimpleBotTankLocomotionStrategy(SimpleBotLocomotionStrategyData data)
        {
            _data = data;
            ChangeDirection();
        }

        public void ChangeDirection()
        {
            var randomAngle = Random.Range(0f, 360f);
            _desiredRotation = Quaternion.Euler(0f, randomAngle, 0f);
            _timeSinceLastDirectionChange = 0f;
        }

        public void Tick()
        {
            // Rotate
            // var isRotationCompleted = Quaternion.Angle(Tank.transform.rotation, _desiredRotation) < 0.1f;
            var isRotationCompleted = Mathf.Abs(Tank.transform.rotation.eulerAngles.y - _desiredRotation.eulerAngles.y) < 0.1f;
            if (isRotationCompleted == false)
            {
                if (_locomotionState != BotLocomotionState.Rotation)
                {
                    _locomotionState = BotLocomotionState.Rotation;
                }
                var step = LocomotionSettings.RotateSpeedEulerPerSecond * Time.deltaTime;
                Tank.transform.rotation = Quaternion.RotateTowards(Tank.transform.rotation, _desiredRotation, step);
                BotObstacleHandler.gameObject.SetActive(false);
                return;
            }

            // Fire event when completed rotation 
            var isRotationCompletedFirstTime = isRotationCompleted && _locomotionState == BotLocomotionState.Rotation;
            if (isRotationCompletedFirstTime)
            {
                _locomotionState = BotLocomotionState.Moving;
            }
            
            
            
            // Move
            var forwardDeltaLocal = LocomotionSettings.MoveSpeedUnitsPerSecond * Time.deltaTime;
            var forwardDeltaWorld = Tank.transform.forward * forwardDeltaLocal;
            Tank.Move(forwardDeltaWorld);
            
            _timeSinceLastDirectionChange += Time.deltaTime;
            if (_timeSinceLastDirectionChange > _data.CooldownSecondsChangeDirection)
            {
                ChangeDirection();
            }

            BotObstacleHandler.gameObject.SetActive(true);
        }
        
        public void FixedTick()
        { }
    }
}