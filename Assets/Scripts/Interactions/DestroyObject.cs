using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    CollectableTracker _collectableTracker;
  
    public void Remove(Collider col)
    {
        _collectableTracker.addCurrentNumber(1);
        // Debug.Log(_collectableTracker.getCurrentNumber());
        this.gameObject.SetActive(false);
    }
}
