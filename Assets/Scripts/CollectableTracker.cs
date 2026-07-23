using UnityEngine;

public class CollectableTracker : MonoBehaviour
{
    public int maxNumber = 30;
    int _currentNumber = 0;

    void Start()
    {
        _currentNumber = 0;
    }

    public void addCurrentNumber(int val)
    {
        _currentNumber = _currentNumber+ val;
    }
    public void setCurrentNumber(int val)
    {
        _currentNumber = val;
    }

    public int getCurrentNumber()
    {return _currentNumber;
    }
}
