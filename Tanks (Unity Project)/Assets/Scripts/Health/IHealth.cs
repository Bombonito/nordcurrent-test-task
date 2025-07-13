using System;

namespace Health
{
    public interface IHealth
    {
        int Current { get; }
        int Maximum { get; }

        event Action OutOfHealth;

        void Set(int newCurrentHealth);
        void Change(int deltaHealth);
    }
}