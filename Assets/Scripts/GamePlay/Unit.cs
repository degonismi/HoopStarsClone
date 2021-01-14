using System;
using UnityEngine;

namespace HoopStar
{
    public class Unit : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private UnitType _unitType;

        private UnitSettingsData _unitSettingsData;

        protected void Awake()
        {
            _unitSettingsData = Resources.Load<UnitSettingsData>("UnitSettingsData");
        }

        private void Start()
        {
            _rigidbody.mass = _unitSettingsData.UnitMass;
        }

        public void Impulse(ImpulseSide side)
        {
            _rigidbody.velocity = Vector3.zero;
            Vector3 impulse;
            
            switch (side)
            {
                case ImpulseSide.Left:
                    impulse = new Vector3(-_unitSettingsData.SideOffset, 1).normalized * _unitSettingsData.ImpulseForce;
                    break;
                case ImpulseSide.Right:
                    impulse = new Vector3(_unitSettingsData.SideOffset, 1).normalized * _unitSettingsData.ImpulseForce;
                    break;
                default:
                    impulse = Vector3.zero;
                    break;
            }
            
            _rigidbody.AddForce(impulse, ForceMode.Impulse);
        }

        public void AddScore()
        {
            GameLoop.Instance.AddScore(_unitType);
        }
    }

    public enum UnitType
    {
        Player,
        Bot
    }

    public enum ImpulseSide
    {
        Left,
        Right
    }
}