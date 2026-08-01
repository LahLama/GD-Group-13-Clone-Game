using UnityEngine;

public class PickUp : MonoBehaviour, IInteractable
{
    
    InventoryManager inventoryManager;

    void Start()
    {        
        inventoryManager = FindAnyObjectByType<InventoryManager>();
        if(!inventoryManager)
        {
            Debug.LogWarning("Can't find the inv manager");
        }
         if (!inventoryManager.playerHand)
        {Debug.LogWarning("NO HAND found");}
    }
    public void Interact(Collider col)
    {

        //  Disble rendering, stack, 
        //  When going out, the reverse
        //  Scroll Wheel 
        bool canPickUp = inventoryManager.playerHand.transform.childCount < inventoryManager.HoldingLimit;
        
        
        if (canPickUp)
            {
                transform.SetParent(inventoryManager.playerHand.transform);
                int slotsLeft = inventoryManager.HoldingLimit - inventoryManager.playerHand.transform.childCount;
                Rigidbody rb = GetComponent<Rigidbody>();
                GetComponent<Collider>().enabled = false;
                rb.useGravity = false;
                rb.freezeRotation = true;
                rb.freezeRotation = true;
                rb.linearVelocity = Vector3.zero;
                transform.position = inventoryManager.playerHand.transform.position;
                Debug.Log("You can pick up "+ slotsLeft + " more items!");

                if (inventoryManager.playerHand.transform.childCount > 1)
                GetComponent<MeshRenderer>().enabled = false;
            }
        else
        {
            Debug.Log("YOU CANT PICK UP ANYMORE!");
        }
     
    }

   
}
