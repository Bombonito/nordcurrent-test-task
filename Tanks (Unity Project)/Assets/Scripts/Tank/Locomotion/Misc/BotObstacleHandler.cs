using System;
using Tank.Locomotion.Strategies;
using Tank.Locomotion.Strategies.SimpleBot;
using UnityEngine;
using Zenject;

namespace Tank.Locomotion.Misc
{
    public class BotObstacleHandler : MonoBehaviour
    {
        [Inject] public ITankLocomotion TankLocomotion { get; }
        
        private void OnTriggerEnter(Collider other)
        {
            var isObstacleHit = other.gameObject.TryGetComponent<IBotLocomotionObstacle>(out _);

            if (isObstacleHit && TankLocomotion.LocomotionStrategy is IBotLocomotionApi botLocomotionApi)
            {
                botLocomotionApi.ChangeDirection();
            }
        }
    }
}