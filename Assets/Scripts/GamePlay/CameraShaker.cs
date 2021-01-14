using System;
using DG.Tweening;
using UnityEngine;

namespace HoopStar
{
    [RequireComponent(typeof(Camera))]
    public class CameraShaker : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private float _shakeDuration;
        [SerializeField] private float _shakeStrength;

        #region Initialization

        private void Reset()
        {
            _camera = GetComponent<Camera>();
        }

        private void Awake()
        {
            if (_camera == null)
            {
                _camera = GetComponent<Camera>();
            }
        }
        
        private void Start()
        {
            GameLoop.Instance.OnPlayerGetScoreAction += Shake;
        }
        
        private void OnDestroy()
        {
            GameLoop.Instance.OnPlayerGetScoreAction -= Shake;
        }
        
        #endregion
        
        private void Shake(int _)
        {
            transform.DOShakePosition(_shakeDuration, _shakeStrength);
        }
    }
}