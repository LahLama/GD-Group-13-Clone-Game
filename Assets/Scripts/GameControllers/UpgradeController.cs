using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeController : MonoBehaviour
{
    [Header("Player")]
    public InventoryManager inventoryManager;
    public PlayerMovement playerMovement;
    public PlayerInteract playerInteract;
    public TrashVisual trashVisual;

    [Header("Money")]
    public MoneyTracking moneyTracking;


    [Header("Upgrade Costs")]
    public int movementCost = 1;
    public int rangeCost = 1;
    public int carryCapacityCost = 1;
    public int xrayCost = 1;
    public int binCost = 1;

    [Header("Upgrade Panels")]
    public GameObject movementPanel;
    public GameObject rangePanel;
    public GameObject carryPanel;
    public GameObject xrayPanel;
    public GameObject binPanel;

    // Movement
    private TMP_Text mText;
    private Button mButton;
    private TMP_Text mbText;
    private int mCount = 0;
    // Range
    private TMP_Text rText;
    private Button rButton;
    private TMP_Text rbText;
    private int rCount = 0;
    // Carry Capacity
    private TMP_Text cText;
    private Button cButton;
    private TMP_Text cbText;
    private int cCount = 0;
    // X-ray
    private TMP_Text xText;
    private Button xButton;
    private TMP_Text xbText;
    private int xCount = 0;
    // Bin
    private TMP_Text bText;
    private Button bButton;
    private TMP_Text bbText;
    private int bCount = 0;

    void Start()    // set all default costs
    {   
        mbText = movementPanel.GetComponentInChildren<Button>().GetComponentInChildren<TMP_Text>();
        rbText = rangePanel.GetComponentInChildren<Button>().GetComponentInChildren<TMP_Text>();
        cbText = carryPanel.GetComponentInChildren<Button>().GetComponentInChildren<TMP_Text>();
        xbText = xrayPanel.GetComponentInChildren<Button>().GetComponentInChildren<TMP_Text>();
        bbText = binPanel.GetComponentInChildren<Button>().GetComponentInChildren<TMP_Text>();
        
        mbText.text = "R" + movementCost;
        rbText.text = "R" + rangeCost;
        cbText.text = "R" + carryCapacityCost;
        xbText.text = "R" + xrayCost;
        bbText.text = "R" + binCost;
    }

    // Movement
    public void UpgradeMovement()   // increase player speed
    {
        int money = moneyTracking.GetMoneyValue();

        bool check = false; // check for whether upgrade was successful

        switch (mCount)
        {
            case 0:
                if (money >= movementCost)  // checks affordability
                {
                    moneyTracking.SubMoneyValue(movementCost);  // subtracts upgrade cost
                    playerMovement.walkMod += 2;    // upgrade modifiers
                    playerMovement.sprintMod += 2;

                    check = true;   // upgrade completed
                }

                break;
            case 2:
                Debug.Log(1);
                break;
            default:
                Debug.Log("brokey");
                break;
        }

        if (check)  // if successful upgrade will increase in level and the cost
        {
            mCount++;
            
            movementCost *= 2;
            mbText.text = "R" + movementCost;
        }    
        
        if (mCount >= 3)    // disables button after max upgrades reached
        {
            mbText.text = "Max";
            mButton.interactable = false;
        } 
    }

    // Range
    public void UpgradeRange()  // increase pickup range
    {
        int money = moneyTracking.GetMoneyValue();

        bool check = false;

        switch (rCount)
        {
            case 0:
               if (money >= rangeCost)  // checks affordability
                {
                    moneyTracking.SubMoneyValue(rangeCost);  // subtracts upgrade cost
                    trashVisual.trashVisualDuration += 2;

                    check = true;   // upgrade completed
                }

                break;
            case 2:
                Debug.Log(1);
                break;
            default:
                Debug.Log("brokey");
                break;
        }

        if (check) rCount++;

        if (check)  // if successful upgrade will increase in level and the cost
        {
            rCount++;
            
            rangeCost *= 2;
            rbText.text = "R" + rangeCost;
        }    
    }

    // Carry Capacity
    public void UpgradeCarry()  // increase carry capacity 
    {
        int money = moneyTracking.GetMoneyValue();

        bool check = false;

        switch (cCount)
        {
            case 0:
                Debug.Log(0);
                break;
            case 2:
                Debug.Log(1);
                break;
            default:
                Debug.Log("brokey");
                break;
        }

        if (check) cCount++;
    }

    // X-ray
    public void UpgradeXray()   // increase duration
    {
        int money = moneyTracking.GetMoneyValue();

        bool check = false;

        switch (xCount)
        {
            case 0:
                Debug.Log(0);
                break;
            case 2:
                Debug.Log(1);
                break;
            default:
                Debug.Log("brokey");
                break;
        }

        if (check) xCount++;
    }

    // Bin Unlock
    public void UpgradeBin()    // unlocks each bin individually
    {
        int money = moneyTracking.GetMoneyValue();

        bool check = false;

        switch (bCount)
        {
            case 0:
                Debug.Log(0);
                break;
            case 2:
                Debug.Log(1);
                break;
            default:
                Debug.Log("brokey");
                break;
        }

        if (check) bCount++;
    }
}
