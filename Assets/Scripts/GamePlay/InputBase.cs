using UnityEngine;

namespace HoopStar
{
    [RequireComponent(typeof(Unit))]
    public class InputBase : MonoBehaviour
    {
        [SerializeField] protected Unit _unit;

        private void Reset()
        {
            _unit = GetComponent<Unit>();
        }

        private void Awake()
        {
            if (_unit == null)
                _unit = GetComponent<Unit>();
        }
    }
}
