
using UnityEngine;

public class CollectableTracker : MonoBehaviour
{
    public int maxNumber = 30;
    int _currentNumber = 0;
    MoneyTracking moneyTracking;



    void Start()
    {
        _currentNumber = 0;
        moneyTracking = FindAnyObjectByType<MoneyTracking>();
        maxNumber = this.transform.childCount;
    }

    public void addCurrentNumber(int val)
    {
        _currentNumber = _currentNumber+ val;
        moneyTracking.AddMoneyValue(5);
       
    }
    public void setCurrentNumber(int val)
    {
        _currentNumber = val;
    }

    public int getCurrentNumber()
    {return _currentNumber;
    }
    public int getCollectiblesLeft()
    {return maxNumber - _currentNumber;
    }
}
