using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace HoopStar.UI
{
    public class RestartGameButtonUi : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private void Start()
        {
            _button.onClick.AddListener((() =>
            {
                GameLoop.Instance.OnRestartGameAction?.Invoke();
            }));
        }
    }
}
