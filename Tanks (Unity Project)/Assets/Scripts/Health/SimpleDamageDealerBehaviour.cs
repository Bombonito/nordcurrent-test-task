using System;
using UnityEngine;

namespace Health
{
    public class SimpleDamageDealerBehaviour : MonoBehaviour, IDamageDealer
    {
        [SerializeField] private int _damage;
        [SerializeField] private bool _destroyOnDamage;

        public int Damage => _damage;
        public event Action DamageDealt;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<IDamageAcceptor>(out var acceptor) == false)
                return;

            acceptor.Process(this);
            DamageDealt?.Invoke();
            if (_destroyOnDamage)
            {
                Deactivate();
            }
        }
        
        public void Deactivate()
        {
            Destroy(gameObject);
        }
    }
}