using UnityEngine;

public class InteractCounter : MonoBehaviour, IInteractable
{
    int num = 0;
    void Start()
    {
       num = 0; 
    }
    public void Interact(Collider col)
    {
        Debug.Log(num++);;
    }
}
