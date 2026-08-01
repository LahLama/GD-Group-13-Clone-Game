using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class ThrowAway : MonoBehaviour
{
  

    InputSystem_Actions inputActions;
    InventoryManager inventoryManager;
    public float throwStrength = 10;
    bool isThrowing = false;
    bool hasThrown = false;

    [SerializeField] List<GameObject> heldItems;
    GameObject CollectibleContainer;
    
    private void Awake() {
        inputActions = new InputSystem_Actions();
        inventoryManager = FindAnyObjectByType<InventoryManager>();
        CollectibleContainer = GameObject.FindGameObjectWithTag("CollectibleContainer");
       
    }
    void OnEnable()
    {
        inputActions.Enable();
    }
    void OnDisable()
    {
        inputActions.Disable();
    }

   private void OnTransformChildrenChanged()
    {
    heldItems.Clear();
    foreach (Transform child in inventoryManager.playerHand.transform)
    {
        heldItems.Add(child.gameObject);
    }

    }

    

    private void Update() {

       

        if (heldItems.Count > 0)
        {
            // isThrowing= inputActions.UI.RightClick.IsPressed();
            // if (isThrowing){
            //     // Debug.Log("PULLING BACK");
                
            //     }
            
            hasThrown = inputActions.UI.RightClick.WasReleasedThisFrame();
            if (hasThrown)
            {
            // Debug.Log("PUH!");
             Rigidbody rb = heldItems[0].GetComponent<Rigidbody>();
            rb.AddForce(inventoryManager.playerHand.transform.forward * throwStrength, ForceMode.Impulse);  
            rb.useGravity = true;
            rb.freezeRotation = false;   
            heldItems[0].gameObject.GetComponent<Collider>().enabled = true;
            heldItems[0].transform.SetParent(CollectibleContainer.transform); //This calls the above function immediately, should be last call here.

            // Since item was removed from parent, new [0] will be the next top 
            heldItems[0].GetComponent<MeshRenderer>().enabled = true;

            }
        }
    }
}
