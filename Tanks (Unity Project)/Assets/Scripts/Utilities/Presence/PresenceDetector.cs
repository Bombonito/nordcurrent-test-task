using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Utilities.Presence
{
    public class PresenceDetector : MonoBehaviour
    {
        private List<PresenceIndicator> _indicators = new List<PresenceIndicator>();

        public int PresenceCount => _indicators.Count;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<PresenceIndicator>(out var indicator) == false)
                return;

            if (_indicators.Contains(indicator))
                return;
            
            _indicators.Add(indicator);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.TryGetComponent<PresenceIndicator>(out var indicator) == false)
                return;

            _indicators.Remove(indicator);
        }

        private void LateUpdate()
        {
            _indicators.RemoveAll(x => x is null || x == false);
        }
    }
}