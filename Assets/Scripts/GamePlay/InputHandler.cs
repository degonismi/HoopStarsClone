using System;
using UnityEngine;

namespace HoopStar
{
    public class InputHandler : MonoBehaviour
    {
        #region Singleton

        public static InputHandler Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }
        }

        #endregion
        
        public Action<ImpulseSide> OnPlayerImpulseAction;

        public void PlayerImpulseLeft()
        {
            OnPlayerImpulseAction?.Invoke(ImpulseSide.Left);
        }
        
        public void PlayerImpulsRigft()
        {
            OnPlayerImpulseAction?.Invoke(ImpulseSide.Right);
        }

    }
}