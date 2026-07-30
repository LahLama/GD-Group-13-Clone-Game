using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    InputSystem_Actions inputActions;
    SceneController sc;

    public GameObject menuPanel;
    public GameObject reticle;

    void Awake()
    {
        inputActions = new InputSystem_Actions();
        sc = FindAnyObjectByType<SceneController>();

        menuPanel.SetActive(false);
    }

    void OnEnable()
    {
        inputActions.Enable();
    }
    void OnDisable()
    {
        inputActions.Disable();
    }

    void Update()
    {
        bool hasPaused = inputActions.Player.Pause.WasPressedThisFrame();

        if (hasPaused)
        {
            Pause();
        }
    }

    public void Pause()
    {
        if (!menuPanel.activeSelf && PauseController.IsPaused)
        {
            return;
        }

        if (!menuPanel.activeSelf)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        } 

        reticle.SetActive(menuPanel.activeSelf);
        menuPanel.SetActive(!menuPanel.activeSelf);
        PauseController.SetPause(menuPanel.activeSelf);
    }

    public void Return()
    {
        sc.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
