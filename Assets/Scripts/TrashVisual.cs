using UnityEngine;

public class TrashVisual : MonoBehaviour
{
    InputSystem_Actions inputActions;
    bool isTrashCamOn;
    public int trashVisualDuration = 1;
    bool canUseTrashAgain;
    [SerializeField] Camera trashCamera;

    private void Awake() {
        inputActions = new InputSystem_Actions();
        canUseTrashAgain = true;
    }
    void OnEnable()
    {
        inputActions.Enable();
    }
    void OnDisable()
    {
        inputActions.Disable();
    }

    private void Update() {
        isTrashCamOn = inputActions.Upgrades.ViewTrash.WasPressedThisFrame() && canUseTrashAgain;
        
        if (isTrashCamOn){
            trashCamera.gameObject.SetActive(true);
            // Debug.Log("TRASH SHOW");
            canUseTrashAgain = false;
            Invoke("NoTrashVisualAfterDelay",trashVisualDuration);
        }
    }

    private void NoTrashVisualAfterDelay()
    {
        trashCamera.gameObject.SetActive(false);
        canUseTrashAgain = true;
        // Debug.Log("WE ARE NO LONGER LOOKING FOR TRASH");
    }
}
