using System;

namespace Health
{
    public interface IDamageDealer
    {
        int Damage { get; }

        event Action DamageDealt;
        
        void Deactivate();
    }
}