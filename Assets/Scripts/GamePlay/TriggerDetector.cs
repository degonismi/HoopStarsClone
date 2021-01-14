using System;
using UnityEngine;
using UnityEngine.Events;

namespace HoopStar
{
    public class TriggerDetector : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask;
        
        public UnityEvent<GameObject> OnTriggerEnterEvent;
        public UnityEvent<GameObject> OnTriggerExitEvent;

        private void OnTriggerEnter(Collider other)
        {
            if (((1<<other.gameObject.layer) & _layerMask) != 0)
            {
                OnTriggerEnterEvent?.Invoke(other.gameObject);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (((1<<other.gameObject.layer) & _layerMask) != 0)
            {
                OnTriggerExitEvent?.Invoke(other.gameObject);
            }
        }
    }   
}
