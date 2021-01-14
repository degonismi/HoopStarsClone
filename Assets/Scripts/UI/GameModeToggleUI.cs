using UnityEngine;

namespace HoopStar.UI
{
    public class GameModeToggleUI : MonoBehaviour
    {
        [SerializeField] private PlayMode playMode;

        public void ChangePlayMode(bool change)
        {
            if (change)
            {
                GameLoop.Instance.OnPlayModeChangeAction?.Invoke(playMode);
            }
        }
    }
}
