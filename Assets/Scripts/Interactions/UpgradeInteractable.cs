using UnityEngine;

public class UpgradeInteractable : MonoBehaviour, IInteractable
{
    public GameObject upgradeMenu;

    public void Interact(Collider col)
    {
        if (!upgradeMenu.activeSelf)
        {
            upgradeMenu.SetActive(true); 
        }

        PauseController.SetPause(upgradeMenu.activeSelf);
    }
}
