using UnityEngine;

namespace Tank.Locomotion.Settings
{
    [CreateAssetMenu(menuName = "Modules/Tank/Locomotion/Settings", fileName = "Tank Locomotion (default)")]
    public class LocomotionSettings : ScriptableObject
    {
        public float MoveSpeedUnitsPerSecond;
        public float RotateSpeedEulerPerSecond;
    }
}