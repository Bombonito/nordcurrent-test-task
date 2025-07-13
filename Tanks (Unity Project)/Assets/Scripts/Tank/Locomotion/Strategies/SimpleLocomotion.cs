namespace Tank.Locomotion.Strategies
{
    public class SimpleLocomotion : ITankLocomotion
    {
        public ITankLocomotionStrategy LocomotionStrategy { get; private set; }
        
        public void Set(ITankLocomotionStrategy locomotionStrategy)
        {
            LocomotionStrategy = locomotionStrategy;
        }

        public void Tick() => LocomotionStrategy?.Tick();

        public void FixedTick() => LocomotionStrategy?.FixedTick();
    }
}