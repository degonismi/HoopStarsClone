using System;
using System.Collections.Generic;
using UnityEngine;

namespace HoopStar
{
    //Скрипт для изменения активных GO в зависимости от PlayMode
    public class PlayModeHandler : MonoBehaviour
    {
        [SerializeField] private List<PlayModeChangeListener> _playModeChangeListeners;

        private void Start()
        {
            GameLoop.Instance.OnPlayModeChangeAction += ChangeState;
        }

        private void ChangeState(PlayMode playMode)
        {
            foreach (var item in _playModeChangeListeners)
            {
                if (item.PlayMode == playMode)
                {
                    item.TargetGameObject.SetActive(item.Enabled);
                }
            }
        }
    }
    
    [Serializable]
    public class PlayModeChangeListener
    {
        public PlayMode PlayMode;
        public GameObject TargetGameObject;
        public bool Enabled;
    }
}