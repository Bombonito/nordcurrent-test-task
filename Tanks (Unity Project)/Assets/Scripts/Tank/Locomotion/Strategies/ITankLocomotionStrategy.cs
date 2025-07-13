namespace Tank.Locomotion.Strategies
{
    public interface ITankLocomotionStrategy
    {
        void Tick();
        void FixedTick();
    }
}