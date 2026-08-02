using UnityEngine;

public class BinTrash : MonoBehaviour
{
    CollectableTracker collectableTracker;
    MoneyTracking moneyTracking;

    void Start()
    {
        collectableTracker = FindAnyObjectByType<CollectableTracker>();
        moneyTracking = FindAnyObjectByType<MoneyTracking>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(tag))
        {
            if (CompareTag("FoodWaste"))
            {
                moneyTracking.AddMoneyValue(1);
            }
            else if (CompareTag("GeneralWaste"))
            {
                moneyTracking.AddMoneyValue(5);
            }
            else if (CompareTag("Paper"))
            {
                moneyTracking.AddMoneyValue(10);
            }
            else if (CompareTag("Plastic"))
            {
                moneyTracking.AddMoneyValue(20);
            }
            else Debug.Log("trashhhhh");

            collectableTracker.addCurrentNumber(1);
            // Debug.Log(collectableTracker.getCurrentNumber());

            Debug.Log("You need "+ collectableTracker.getCollectiblesLeft() + "more trash to complete the level!");

            collision.gameObject.SetActive(false);
        }
    }
}
