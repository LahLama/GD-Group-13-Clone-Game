using UnityEngine;
using TMPro;

public class MoneyTracking : MonoBehaviour
{
    public TextMeshProUGUI moneyAmount;
    int moneyNumber = 0;
    public void SetMoneyValue(int val)
    {
        moneyNumber = val;
        moneyAmount.text = "R"+moneyNumber;
        
    }
    public void AddMoneyValue(int val)
    {
        moneyNumber += val;
        moneyAmount.text  = "R"+moneyNumber;
    }
}
