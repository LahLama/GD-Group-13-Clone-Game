using UnityEngine;

public class BinTrash : MonoBehaviour
{
    CollectableTracker collectableTracker;

    void Start()
    {
        collectableTracker = FindAnyObjectByType<CollectableTracker>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(this.tag))
        {
            collectableTracker.addCurrentNumber(1);
            Debug.Log(collectableTracker.getCurrentNumber());
            
            collision.gameObject.SetActive(false);
        }
    }
}
