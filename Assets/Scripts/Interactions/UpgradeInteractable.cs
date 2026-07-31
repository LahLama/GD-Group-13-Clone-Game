using UnityEngine;

public class UpgradeInteractable : MonoBehaviour, IInteractable
{
    public GameObject upgradeMenu;
    public GameObject reticle;

    void Awake()
    {
        upgradeMenu.SetActive(false);
    }

    public void Interact(Collider col)
    {
        if (!upgradeMenu.activeSelf && !PauseController.IsPaused)
        {
            upgradeMenu.SetActive(true);
            reticle.SetActive(false); 

            Cursor.lockState = CursorLockMode.None;
        }

        PauseController.SetPause(upgradeMenu.activeSelf);
    }
}
