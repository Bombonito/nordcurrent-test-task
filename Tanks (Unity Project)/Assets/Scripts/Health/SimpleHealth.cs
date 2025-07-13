using System;

namespace Health
{
    public class SimpleHealth : IHealth
    {
        private int _current;
        private int _maximum;
        
        public int Current => _current;
        public int Maximum => _maximum;
        
        public event Action OutOfHealth;

        public SimpleHealth(int current, int maximum)
        {
            _current = current;
            _maximum = maximum;
        }
        
        public void Set(int newCurrentHealth)
        {
            _current = Math.Clamp(newCurrentHealth, 0, _maximum);
            CheckIfOutOfHealth();
        }

        public void Change(int deltaHealth)
        {
            _current = Math.Clamp(_current + deltaHealth, 0, _maximum);
            CheckIfOutOfHealth();
        }

        private void CheckIfOutOfHealth()
        {
            if (Current <= 0)
                OutOfHealth?.Invoke();
        }
    }
}