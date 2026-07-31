using UnityEngine;

public class MainMenu : MonoBehaviour
{
    SceneController sController;

    void Awake()
    {
        sController = FindAnyObjectByType<SceneController>();
    }

    public void StartGame(int sceneIndex)
    {
        if (sController == null)
        {
            sController = FindAnyObjectByType<SceneController>();
        }

        sController.LoadScene(sceneIndex);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
