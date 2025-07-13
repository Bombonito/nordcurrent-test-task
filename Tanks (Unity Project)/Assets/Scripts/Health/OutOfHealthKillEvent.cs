using System;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Health
{
    public class OutOfHealthKillEvent : MonoBehaviour
    {
        [SerializeField] private GameObject _target;
        
        [Inject] public IHealth Health { get; }

        public UnityEvent OutOfHealth;

        private void Start()
        {
            Health.OutOfHealth += OnOutOfHealth;
        }

        private void OnOutOfHealth()
        {
            OutOfHealth?.Invoke();
            Destroy(_target);
        }
    }
}