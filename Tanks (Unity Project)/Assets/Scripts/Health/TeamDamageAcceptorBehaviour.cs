using Tank.Team;
using UnityEngine;
using Zenject;

namespace Health
{
    public class TeamDamageAcceptorBehaviour : MonoBehaviour, IDamageAcceptor
    {
        [Inject] public IHealth TargetHealth { get; }
        [InjectOptional] public ITeam Team { get; }

        public void Process(IDamageDealer damageDealer)
        {
            TargetHealth.Change(damageDealer.Damage * -1);
        }
    }
}