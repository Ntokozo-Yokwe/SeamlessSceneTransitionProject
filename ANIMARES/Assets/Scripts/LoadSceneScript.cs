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
            //scenesToLoad.Add(SceneManager.LoadSceneAsync("Scene2", LoadSceneMode.Additive));
            StartCoroutine(LoadingScreen());
        }
        isLoaded = true;
    }

    //make a method for the object clicked scene switch to load the final scene and unload the first scene(SampleScene)
    //public void FinalScene()
    //{
    //  Call functions that handle the fade out of the other objects and of the centering of pressed object
    //  and the next scene should load the object with a fade in
    //}

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
        yield return new WaitForSeconds(2);
        gameLevel.allowSceneActivation = true;
        //SceneManager.UnloadSceneAsync("SampleScene");
    }
}
///////////////////---WE CAN DO THIS SCENE TRANSITION ON AWAKE---////////////////////////