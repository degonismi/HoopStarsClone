using UnityEngine;

namespace HoopStar
{
    public class TargetHandler : MonoBehaviour
    {
        //Хардом забиты положения для рандомного перемещения цели
        [SerializeField] private float _offsetX;
        [SerializeField] private float _offsetYmin;
        [SerializeField] private float _offsetYmax;

        private void Start()
        {
            GameLoop.Instance.OnStartGameAction += StartGame;
        }

        private void StartGame()
        {
            switch (GameLoop.Instance.PlayMode)
            {
                case PlayMode.Single:
                    GameLoop.Instance.OnPlayerGetScoreAction += ChangePosition;
                    GameLoop.Instance.OnEnemyGetScoreAction += ChangePosition;
                    break;
                case PlayMode.DuelMoveTarget:
                    GameLoop.Instance.OnPlayerGetScoreAction += ChangePosition;
                    GameLoop.Instance.OnEnemyGetScoreAction += ChangePosition;
                    break;
            }
        }

        private void ChangePosition(int _)
        {
            transform.position = new Vector3(Random.Range(-_offsetX, _offsetX), Random.Range(_offsetYmin, _offsetYmax));
        }
    }
}