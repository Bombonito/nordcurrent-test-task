using Zenject;

namespace Tank.Locomotion.Strategies
{
    public interface ITankLocomotion : ITickable, IFixedTickable
    {
        ITankLocomotionStrategy LocomotionStrategy { get; }
        void Set(ITankLocomotionStrategy locomotionStrategy);
    }
}