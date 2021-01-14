using System.Collections;
using UnityEngine;

namespace HoopStar
{
    //Черновой вариант бота, для прототипа, последующих итерацией было бы изменение его поведения:
    //подстройка под входные параметры, и внедрение коэфициента сложности
    //из-за нехватки времени пришлось захардкодить, под текущие настройки(
    public class BotInput : InputBase 
    {
        public Transform TargetTransform;
        public float BotInputCooldown;
        public float BotSimpleDelay;
        public float MinDistance;
        public float MaxDistance;

        private void Start()
        {
            GameLoop.Instance.OnStartGameAction += () =>
            {
                StartCoroutine(BotBehaviour());
            };
        }

        private IEnumerator BotBehaviour()
        {
            float timer = 0;

            while (true)
            {
                ImpulseSide side = (transform.position - TargetTransform.position).x < 0
                    ? ImpulseSide.Right
                    : ImpulseSide.Left;

                timer -= Time.deltaTime;

                if (timer <= 0)
                {
                    float distance = Vector3.Distance(transform.position, TargetTransform.position);

                    if (distance > MaxDistance)
                    {
                        if ((TargetTransform.position - transform.position).y > 0)
                            _unit.Impulse(side);

                        timer = BotInputCooldown;
                    }
                    else if (distance > MinDistance)
                    {
                        timer = BotSimpleDelay;
                    }
                    else if (distance < MinDistance)
                    {
                        _unit.Impulse(side);
                        timer = BotInputCooldown;
                    }
                }

                yield return null;
            }
        }
    }
}