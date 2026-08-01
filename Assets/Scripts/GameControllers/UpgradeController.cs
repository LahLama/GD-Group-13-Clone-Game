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

    [Header("Bin States")]
    public Animator foodBin;
    public Animator GeneralBin;
    public Animator ContainerBin;
    public Animator BottlesBin;

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
        mText = movementPanel.GetComponentInChildren<TMP_Text>();
        rText = rangePanel.GetComponentInChildren<TMP_Text>();
        cText = carryPanel.GetComponentInChildren<TMP_Text>();
        xText = xrayPanel.GetComponentInChildren<TMP_Text>();
        bText = binPanel.GetComponentInChildren<TMP_Text>();

        mButton = movementPanel.GetComponentInChildren<Button>();
        rButton = rangePanel.GetComponentInChildren<Button>();
        cButton = carryPanel.GetComponentInChildren<Button>();
        xButton = xrayPanel.GetComponentInChildren<Button>();
        bButton = binPanel.GetComponentInChildren<Button>();

        mbText = mButton.GetComponentInChildren<TMP_Text>();
        rbText = rButton.GetComponentInChildren<TMP_Text>();
        cbText = cButton.GetComponentInChildren<TMP_Text>();
        xbText = xButton.GetComponentInChildren<TMP_Text>();
        bbText = bButton.GetComponentInChildren<TMP_Text>();
        
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
                    playerMovement.walkMod += 1;    // upgrade modifiers
                    playerMovement.sprintMod += 1;

                    mText.text += "I";

                    check = true;   // upgrade completed
                }
                break;
            case 1:
                if (money >= movementCost)  
                {
                    moneyTracking.SubMoneyValue(movementCost); 
                    playerMovement.walkMod += 1;    
                    playerMovement.sprintMod += 1;

                    mText.text += "I";

                    check = true;  
                }
                break;
            case 2:
                if (money >= movementCost)  
                {
                    moneyTracking.SubMoneyValue(movementCost); 
                    playerMovement.walkMod += 2;    
                    playerMovement.sprintMod += 2;

                    mText.text += "I";

                    check = true;  
                }
                break;
            default:
                Debug.Log("brokey");
                break;
        }

        if (check)  // if successful upgrade will increase in level and the cost
        {
            mCount++;
            
            movementCost *= 10;
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
                if (money >= rangeCost)  
                {
                    moneyTracking.SubMoneyValue(rangeCost);  
                    playerInteract.range += 1;

                    rText.text += "I";

                    check = true;   
                }
                break;
            case 1:
                if (money >= rangeCost)  
                {
                    moneyTracking.SubMoneyValue(rangeCost); 
                    playerInteract.range += 1;

                    rText.text += "I";

                    check = true;  
                }
                break;
            case 2:
                if (money >= rangeCost) 
                {
                    moneyTracking.SubMoneyValue(rangeCost);  
                    playerInteract.range += 1;

                    rText.text += "I";

                    check = true;   
                }
                break;
            default:
                Debug.Log("brokey");
                break;
        }

        if (check) 
        {
            rCount++;
            
            rangeCost *= 3;
            rbText.text = "R" + rangeCost;
        }    

        if (rCount >= 3)   
        {
            rbText.text = "Max";
            rButton.interactable = false;
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
                if (money >= carryCapacityCost) 
                {
                    moneyTracking.SubMoneyValue(carryCapacityCost); 
                    inventoryManager.HoldingLimit += 1;

                    check = true;   
                }
                break;
            case 1:
                if (money >= carryCapacityCost) 
                {
                    moneyTracking.SubMoneyValue(carryCapacityCost); 
                    inventoryManager.HoldingLimit += 2;

                    check = true;   
                }
                break;
            case 2:
                if (money >= carryCapacityCost) 
                {
                    moneyTracking.SubMoneyValue(carryCapacityCost); 
                    inventoryManager.HoldingLimit += 3;

                    check = true;   
                }
                break;
            default:
                Debug.Log("brokey");
                break;
        }

        if (check)  
        {
            cCount++;
            
            carryCapacityCost *= 5;
            cbText.text = "R" + carryCapacityCost;
        }   

        if (cCount >= 3)    
        {
            cbText.text = "Max";
            cButton.interactable = false;
        }
    }

    // X-ray
    public void UpgradeXray()   // increase duration
    {
        int money = moneyTracking.GetMoneyValue();

        bool check = false;

        switch (xCount)
        {
            case 0:
                if (money >= xrayCost) 
                {
                    moneyTracking.SubMoneyValue(xrayCost); 
                    trashVisual.trashVisualDuration += 2;

                    check = true;   
                }
                break;
            case 1:
                if (money >= xrayCost) 
                {
                    moneyTracking.SubMoneyValue(xrayCost); 
                    trashVisual.trashVisualDuration += 2;

                    check = true;   
                }
                break;
            case 2:
                if (money >= xrayCost) 
                {
                    moneyTracking.SubMoneyValue(xrayCost); 
                    trashVisual.trashVisualDuration += 5;

                    check = true;   
                }
                break;
            default:
                Debug.Log("brokey");
                break;
        }

        if (check)  
        {
            xCount++;
            
            xrayCost *= 3;
            xbText.text = "R" + xrayCost;
        }   

        if (xCount >= 3)    
        {
            xbText.text = "Max";
            xButton.interactable = false;
        }
    }

    // Bin Unlock
    public void UpgradeBin()    // unlocks each bin individually
    {
        int money = moneyTracking.GetMoneyValue();

        bool check = false;

        switch (bCount)
        {
            case 0:
                if (money >= binCost) 
                {
                    moneyTracking.SubMoneyValue(binCost); 
                    GeneralBin.SetBool("isOpen", true);

                    check = true;   
                }
                break;
            case 1:
                if (money >= binCost) 
                {
                    moneyTracking.SubMoneyValue(binCost); 
                    ContainerBin.SetBool("isOpen", true);

                    check = true;   
                }
                break;
            case 2:
                if (money >= binCost) 
                {
                    moneyTracking.SubMoneyValue(binCost); 
                    BottlesBin.SetBool("isOpen", true);

                    check = true;   
                }
                break;
            default:
                Debug.Log("brokey");
                break;
        }

        if (check)  
        {
            bCount++;
            
            binCost *= 5;
            bbText.text = "R" + binCost;
        }   

        if (bCount >= 3)    
        {
            bbText.text = "Max";
            bButton.interactable = false;
        }
    }
}
