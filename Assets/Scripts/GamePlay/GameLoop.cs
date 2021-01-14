using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HoopStar
{
    public class GameLoop : MonoBehaviour
    {
        #region Singleton

        public static GameLoop Instance { get; private set; }

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

        public PlayMode PlayMode;

        public Action<PlayMode> OnPlayModeChangeAction;
        
        public Action OnStartGameAction;
        public Action OnEndGameAction;
        public Action OnRestartGameAction;

        public int PlayerScore;
        public int EnemyScore;
        
        public Action<int> OnPlayerGetScoreAction;
        public Action<int> OnEnemyGetScoreAction;

        private void Start()
        {
            OnStartGameAction += StartGame;
            OnPlayModeChangeAction += mode => PlayMode = mode;
            OnEndGameAction += () =>
            {
                StartCoroutine(EndGame());
            };

            OnRestartGameAction += () =>
            {
                Time.timeScale = 1;
                SceneManager.LoadSceneAsync(1);
            };
        }

        private void StartGame()
        {
            OnPlayModeChangeAction?.Invoke(PlayMode);
            switch (PlayMode)
            {
                case PlayMode.Single:
                    StartCoroutine(SingleGameCycle());
                    break;
                case PlayMode.Duel:
                    StartCoroutine(DuelGameCycle());
                    break;
                case PlayMode.DuelMoveTarget:
                    StartCoroutine(DuelGameCycle());
                    break;
            }
        }

        private IEnumerator SingleGameCycle() //Вместо проверки на время хотел сделать таймер
        {
            yield return new WaitUntil((() => PlayerScore > 4 || EnemyScore > 4));
            OnEndGameAction?.Invoke();
        }

        private IEnumerator DuelGameCycle()
        {
            yield return new WaitUntil((() => PlayerScore > 4 || EnemyScore > 4));
            OnEndGameAction?.Invoke();
        }

        private IEnumerator EndGame() //Тут должно быть плавное снижение Time.timeScale по кривой
        {
            Time.timeScale = 0.3f;
            yield return new WaitForSeconds(1.5f);
            Time.timeScale = 0;
        }

        public void AddScore(UnitType type)
        {
            switch (type)
            {
                case UnitType.Player:
                    PlayerScore++;
                    OnPlayerGetScoreAction?.Invoke(PlayerScore);
                    break;
                case UnitType.Bot:
                    EnemyScore++;
                    OnEnemyGetScoreAction?.Invoke(EnemyScore);
                    break;
            }
        }
    }

    public enum PlayMode //Базовые режимы игры
    {
        Duel,
        DuelMoveTarget,
        Single
    }
    
}
