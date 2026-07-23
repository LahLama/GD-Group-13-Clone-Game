using UnityEngine;

public class CollectableTrackr : MonoBehaviour
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

    public int getCurrentNumber()
    {return _currentNumber;
    }
}
