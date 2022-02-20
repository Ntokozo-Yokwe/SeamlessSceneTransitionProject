using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField]
    private Image _progressBar;
    // Start is called before the first frame update
    public void StartButton()
    {
        StartCoroutine(LoadAsyncOperatiom());
    }


    IEnumerator LoadAsyncOperatiom()
    {
        AsyncOperation gameLevel = SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
        gameLevel.allowSceneActivation = false; // stop the level from activating

        while (gameLevel.progress < 0.9f)
        {
            _progressBar.fillAmount = gameLevel.progress;
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(3);

        gameLevel.allowSceneActivation = true; // this will enter the level now
        SceneManager.UnloadSceneAsync(0);
    }
}