using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class BeeInteractable : MonoBehaviour
{
    [SerializeField]
    private bool autoTarget = true;
    [SerializeField]
    private bool beeSwap = false;

    private GameObject bee;

    public delegate void OnBeeInteractable();
    public OnBeeInteractable onBeeInteractable;

    public GameObject Bee
    {
        get{ return bee; }
    }

    public void Interact(GameObject incomingBee)
    {
        if(bee != null && bee != incomingBee && !beeSwap) 
        {
            return; // Bee already present.
        }
        
        bee = incomingBee;

        if(onBeeInteractable != null)
        {
            onBeeInteractable.Invoke();
        }

        if(autoTarget)
        {
            // Set current object as bee's target.
            bee.GetComponent<TargetManager>().Target = transform;
        }
    }
}
