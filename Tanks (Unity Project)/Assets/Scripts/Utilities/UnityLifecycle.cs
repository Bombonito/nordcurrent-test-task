using System;
using UnityEngine;
using UnityEngine.Events;

namespace Utilities
{
    public class UnityLifecycle : MonoBehaviour
    {
        public UnityEvent start;
        public UnityEvent awake;
        public UnityEvent enable;
        public UnityEvent disable;
        public UnityEvent update;
        public UnityEvent destroy;

        private void Start() => start?.Invoke();
        private void Awake() => awake?.Invoke();
        private void OnEnable() => enable?.Invoke();
        private void OnDisable() => disable?.Invoke();
        private void Update() => update?.Invoke();
        private void OnDestroy() => destroy?.Invoke();
    }
}