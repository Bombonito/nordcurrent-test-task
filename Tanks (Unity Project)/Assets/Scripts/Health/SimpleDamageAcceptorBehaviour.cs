using UnityEngine;
using Zenject;

namespace Health
{
    public class SimpleDamageAcceptorBehaviour : MonoBehaviour, IDamageAcceptor
    {
        [Inject] public IHealth TargetHealth { get; }

        public void Process(IDamageDealer damageDealer)
        {
            TargetHealth.Change(damageDealer.Damage * -1);
        }
    }
}