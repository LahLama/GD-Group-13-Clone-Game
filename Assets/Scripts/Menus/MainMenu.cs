using UnityEngine;

public class MainMenu : MonoBehaviour
{
    SceneController sController;

    void Start()
    {
        sController = FindAnyObjectByType<SceneController>();
    }

    public void StartGame(int sceneIndex)
    {
        sController.LoadScene(sceneIndex);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
