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
            // Debug.Log(collectableTracker.getCurrentNumber());

            Debug.Log("You need "+ collectableTracker.getCollectiblesLeft() + "more trash to complete the level!");

            collision.gameObject.SetActive(false);
        }
    }
}
