using UnityEngine;

namespace HoopStar
{
    [CreateAssetMenu(order = 0, menuName = "Data/UnitSettings", fileName = "UnitSettings")]
    public class UnitSettingsData : ScriptableObject
    {
        public float ImpulseForce;
        public float UnitMass;
        [Range(0.01f, 1f)]
        public float SideOffset;
    }   
}
