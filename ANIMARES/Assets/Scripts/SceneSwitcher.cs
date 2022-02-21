using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField]
    private Image _progressBar;
    private bool isLoaded;

    public void StartButton()
    {
        if (isLoaded == false)
        {
            StartCoroutine(LoadAsyncOperatiom());
            isLoaded = true;
        }
    }

    IEnumerator LoadAsyncOperatiom()
    {
        AsyncOperation gameLevel = SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);
        gameLevel.allowSceneActivation = false; // stop the level from activating

        while (gameLevel.progress < 0.9f)
        {
            _progressBar.fillAmount = gameLevel.progress;
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(3);

        gameLevel.allowSceneActivation = true; // this will enter the level now
    }

    public void LoadSceneOne()
    {
        SceneManager.LoadScene(0);
    }
}