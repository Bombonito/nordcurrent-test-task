using System;
using UnityEngine;

namespace Utilities
{
    [RequireComponent(typeof(Rigidbody))]
    public class ProjectileMover : MonoBehaviour
    {
        [SerializeField] private Rigidbody _body;
        [SerializeField] private float _speedUnitsPerSecond;
        
        private void Update()
        {
            var deltaMove = transform.forward * (_speedUnitsPerSecond * Time.deltaTime);
            
            _body.MovePosition(_body.transform.position + deltaMove);
        }
        
        #if UNITY_EDITOR
        private void Reset()
        {
            _body = GetComponent<Rigidbody>();
        }
#endif
    }
}