using UnityEngine;

public class PickUp : MonoBehaviour, IInteractable
{
    public GameObject playerHand;
    
    InventoryManager inventoryManager;

    void Start()
    {        
        playerHand = GameObject.FindWithTag("MainHand");
        if (!playerHand)
        {Debug.LogWarning("NO HAND");}

        inventoryManager = FindAnyObjectByType<InventoryManager>();
    }
    public void Interact(Collider col)
    {

        //  Disble rendering, stack, 
        //  When going out, the reverse
        //  Scroll Wheel 
        bool canPickUp = playerHand.transform.childCount < inventoryManager.HoldingLimit;
        
        
        if (canPickUp)
            {
                transform.SetParent(playerHand.transform);
                int slotsLeft = inventoryManager.HoldingLimit - playerHand.transform.childCount;
                Debug.Log("You can pick up "+ slotsLeft + " more items!");
            }
        else
        {
            Debug.Log("YOU CANT PICK UP ANYMORE!");
        }
     
    }

   
}
