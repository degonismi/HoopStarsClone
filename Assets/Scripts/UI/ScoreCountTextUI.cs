using TMPro;
using UnityEngine;

namespace HoopStar.UI
{
    public class ScoreCountTextUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _tmpText;
        [SerializeField] private UnitType _unitType;
        
        private void Start()
        {
            switch (_unitType)
            {
                case UnitType.Player:
                    GameLoop.Instance.OnPlayerGetScoreAction += UpdateScore;
                    break;
                case UnitType.Bot:
                    GameLoop.Instance.OnEnemyGetScoreAction += UpdateScore;
                    break;
            }
        }
        
        private void UpdateScore(int score)
        {
            _tmpText.text = score.ToString();
        }
    }

}