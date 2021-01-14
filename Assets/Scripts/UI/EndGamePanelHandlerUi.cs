using System;
using UnityEngine;

namespace HoopStar.UI
{
    public class EndGamePanelHandlerUi : MonoBehaviour
    {
        private void Start()
        {
            GameLoop.Instance.OnEndGameAction += () =>
            {
                gameObject.SetActive(true);
            };
            gameObject.SetActive(false);
        }
    }
}
