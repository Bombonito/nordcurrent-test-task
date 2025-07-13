using System;
using Tank.Team;
using UnityEngine;
using Zenject;

namespace Health
{
    public class TeamDamageDealerBehaviour : MonoBehaviour, IDamageDealer
    {
        [SerializeField] private int _damage;

        [InjectOptional] public ITeam Team { get; }
        
        public int Damage => _damage;
        public event Action DamageDealt;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<IDamageAcceptor>(out var acceptor) == false)
                return;

            var isOfSameTeam = Team is not null
                               && acceptor is TeamDamageAcceptorBehaviour teamDamageAcceptorBehaviour
                               && Team.IsSameTeam(teamDamageAcceptorBehaviour.Team);

            if (isOfSameTeam)
                return;
            
            acceptor.Process(this);
            DamageDealt?.Invoke();
        }
        
        public void Deactivate()
        {
            Destroy(gameObject);
        }
    }
}