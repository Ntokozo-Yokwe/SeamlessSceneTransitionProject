using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneScript : MonoBehaviour
{
    [SerializeField]
    private Image loadingProgressBar;
    private bool isLoaded;

    // if we need to load/add a couple of scenes at a time
    List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();

    void Start()
    {
        // ensure that we can only run this once
        if(isLoaded == false)
        {
            StartCoroutine(LoadingScreen());
        }
        isLoaded = true;
    }

    IEnumerator LoadingScreen()
    {
        //load additive scene asychronously
        AsyncOperation gameLevel = SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
        // // stop the level from activating
        gameLevel.allowSceneActivation = false;

        float totalProgress = 0;
        //look through the list to see if all scenes have finished loading
        for(int i=0; i<scenesToLoad.Count; ++i)
        {
            while (!scenesToLoad[i].isDone)
            {
                totalProgress += scenesToLoad[i].progress;
                loadingProgressBar.fillAmount = totalProgress / scenesToLoad.Count;
                yield return null;
            }
        }
        // pause the activation just so that we can add functionality to previous scene objects
        yield return new WaitForSeconds(3);
        // this will enter the level now
        gameLevel.allowSceneActivation = true;
    }
}