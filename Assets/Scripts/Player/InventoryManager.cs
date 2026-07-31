using Unity.VisualScripting;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
     public int HoldingLimit = 2;
     
     
    public GameObject playerHand; 

    private void Awake() {
     playerHand = GameObject.FindWithTag("MainHand");
    }
}
