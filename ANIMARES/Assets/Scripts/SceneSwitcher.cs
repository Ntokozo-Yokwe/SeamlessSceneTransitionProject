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
        // ensure that we can only run this once
        if (isLoaded == false)
        {
            StartCoroutine(LoadAsyncOperatiom());
            isLoaded = true;
        }
    }

    IEnumerator LoadAsyncOperatiom()
    {
        //load additive scene asychronously
        AsyncOperation gameLevel = SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);
        // stop the level from activating
        gameLevel.allowSceneActivation = false;

        //see if scene has loaded
        while (gameLevel.progress < 0.9f)
        {
            _progressBar.fillAmount = gameLevel.progress;
            yield return new WaitForEndOfFrame();
        }
        // pause the activation just so that we can add functionality to previous scene objects
        yield return new WaitForSeconds(3);
        // this will enter the level now
        gameLevel.allowSceneActivation = true; 
    }

    //for the restart button (restart whole application)
    public void LoadSceneOne()
    {
        SceneManager.LoadScene(0);
    }
}