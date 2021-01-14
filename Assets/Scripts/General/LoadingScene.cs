using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HoopStar
{
    public class LoadingScene : MonoBehaviour
    {
        [SerializeField] private List<string> _loadTexts = new List<string>(3);
        [SerializeField] private TMP_Text _tmpText;
        
        private void Start()
        {
            StartCoroutine(LoadGameplayScene());
        }

        private IEnumerator LoadGameplayScene()
        {
            _tmpText.text = _loadTexts[0];
            yield return new WaitForSeconds(1);
            SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
            _tmpText.text = _loadTexts[1];
            yield return new WaitForSeconds(1);
            _tmpText.text = _loadTexts[2];
            yield return new WaitForSeconds(1);
            SceneManager.UnloadSceneAsync(0);
        }
    }
}
