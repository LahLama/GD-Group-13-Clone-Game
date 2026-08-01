using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public static SceneController instance; //Allows continuous access of this script from anywhere

    public GameObject LoadingCanvas;
    public Slider loadBar;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  //Keeps the empty gameobject with the script active
        }
        else
        {
            Destroy(gameObject);    //If scene has this object already, destroys the duplicate
        }

        LoadingCanvas.SetActive(false);
    }

    public void LoadScene(int sceneIndex)  //Loads a specific scene
    {
        StartCoroutine(LoadSceneCoroutine(sceneIndex));
    }

    IEnumerator LoadSceneCoroutine(int sceneIndex)  //Loads scene in background and monitors progress
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        LoadingCanvas.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);  //Monitored progress for a loading screen
            
            Debug.Log("Loading: " + progress + "%");
            loadBar.value = progress;

            yield return null;
        }

        LoadingCanvas.SetActive(false);
    }
}
