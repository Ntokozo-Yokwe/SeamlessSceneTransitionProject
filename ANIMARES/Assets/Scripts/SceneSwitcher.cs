using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string levelName;

    public void StartGame()
    {
        SceneManager.LoadSceneAsync(levelName);
    }

    public void ObjectSelected()
    {
        SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
    }
    
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
      //  if (collision.collider.gameObject.CompareTag("ReachedEnd"))
        //{
          //  Debug.Log("Finished Game");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //}
//    }
}
