using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneScript : MonoBehaviour
{
    public Image loadingProgressBar;
    private bool isLoaded;

    List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();

    void Start()
    {
        if(isLoaded == false)
        {
            StartCoroutine(LoadingScreen());
        }
        isLoaded = true;
    }

    IEnumerator LoadingScreen()
    {
        AsyncOperation gameLevel = SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);

        gameLevel.allowSceneActivation = false;

        float totalProgress = 0;
        for(int i=0; i<scenesToLoad.Count; ++i)
        {
            while (!scenesToLoad[i].isDone)
            {
                totalProgress += scenesToLoad[i].progress;
                loadingProgressBar.fillAmount = totalProgress / scenesToLoad.Count;
                yield return null;
            }
        }
        yield return new WaitForSeconds(3);
        gameLevel.allowSceneActivation = true;
    }
}