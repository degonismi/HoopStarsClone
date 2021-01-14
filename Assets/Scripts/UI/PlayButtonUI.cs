using UnityEngine;
using UnityEngine.UI;

namespace HoopStar.UI
{
    public class PlayButtonUI : MonoBehaviour
    {
        [SerializeField] private Button _playButton;

        private void Start()
        {
            _playButton.onClick.AddListener((() =>
            {
                GameLoop.Instance.OnStartGameAction?.Invoke();
            }));
        }
    }
}