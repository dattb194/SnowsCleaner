using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoading : MonoBehaviour
{
    public GameObject gamePlay;
    public GameObject loadingUI;
    public Transform loadingImg;
    private void Start()
    {
        //LoadingScene();
    }
    public void LoadingScene()
    {
        StartCoroutine(LoadYourAsyncScene());
    }
    IEnumerator LoadYourAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("gamePlay");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            loadingImg.transform.Rotate(0, 0, 10);
            yield return null;
        }
        //loadingUI.SetActive(false);
    }
}
