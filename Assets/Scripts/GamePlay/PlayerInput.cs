using System;
using UnityEngine;

namespace HoopStar
{
    public class PlayerInput : InputBase
    {
        private void Start()
        {
            InputHandler.Instance.OnPlayerImpulseAction += Impulse;
        }

        private void Impulse(ImpulseSide side)
        {
            _unit.Impulse(side);
        }
    }
}
