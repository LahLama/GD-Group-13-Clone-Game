using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    InputSystem_Actions inputActions;

    public GameObject upgradePanel;
    public GameObject reticle;

    void Awake()
    {
        inputActions = new InputSystem_Actions();

        upgradePanel.SetActive(false);
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
        bool hasClosed = inputActions.Player.Pause.WasPressedThisFrame();

        if (hasClosed)
        {
            Close();
        }
    }

    public void Close()
    {
        if (upgradePanel.activeSelf && PauseController.IsPaused)
        {
            reticle.SetActive(true);
            upgradePanel.SetActive(false); 

            Cursor.lockState = CursorLockMode.Locked;
        }
        
        PauseController.SetPause(upgradePanel.activeSelf);
    }
}
