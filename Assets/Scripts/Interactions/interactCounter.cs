using UnityEngine;

public class InteractCounter : MonoBehaviour, IInteractable
{
    CollectableTracker _collectableTracker;
  
    void Start()
    {
        _collectableTracker = FindAnyObjectByType<CollectableTracker>();
        _collectableTracker.setCurrentNumber(0);

    }
    public void Interact(Collider col)
    {
        _collectableTracker.addCurrentNumber(1);
        Debug.Log(_collectableTracker.getCurrentNumber());
        this.gameObject.SetActive(false);
    }
}
