using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    CollectableTracker _collectableTracker;
  
    void Start()
    {
        _collectableTracker = FindAnyObjectByType<CollectableTracker>();
      

    }
    public void Remove(Collider col)
    {
        _collectableTracker.addCurrentNumber(1);
        Debug.Log(_collectableTracker.getCurrentNumber());
        this.gameObject.SetActive(false);
    }
}
