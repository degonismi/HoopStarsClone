using System;
using UnityEngine;

namespace HoopStar.UI
{
    public class PlayModeHandlerUI : MonoBehaviour
    {
        [SerializeField] private Transform _playerScoreDuelMode;
        [SerializeField] private Transform _enemyScoreDuelMode;
        [SerializeField] private Transform _playerScoreSingleMode;
        
        private void Start()
        {
            GameLoop.Instance.OnPlayModeChangeAction += ChangePlayModeHandler;
        }

        private void ChangePlayModeHandler(PlayMode playMode)
        {
            switch (playMode)
            {
                case PlayMode.Single:
                    _playerScoreDuelMode.gameObject.SetActive(false); 
                    _enemyScoreDuelMode.gameObject.SetActive(false);
                    _playerScoreSingleMode.gameObject.SetActive(true);
                    break;
                case PlayMode.Duel:
                    _playerScoreDuelMode.gameObject.SetActive(true); 
                    _enemyScoreDuelMode.gameObject.SetActive(true);
                    _playerScoreSingleMode.gameObject.SetActive(false);
                    break;
                case PlayMode.DuelMoveTarget:
                    _playerScoreDuelMode.gameObject.SetActive(true); 
                    _enemyScoreDuelMode.gameObject.SetActive(true);
                    _playerScoreSingleMode.gameObject.SetActive(false);
                    break;
            }
        }
    }
}
