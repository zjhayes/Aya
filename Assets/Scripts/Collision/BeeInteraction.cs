using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class BeeInteraction : MonoBehaviour
{
    [SerializeField]
    private bool autoTarget = true;

    private GameObject bee;

    public delegate void OnBeeInteraction();
    public OnBeeInteraction onBeeInteraction;

    public GameObject Bee
    {
        get{ return bee; }
    }

    public void Interact(GameObject incomingBee)
    {
        if(bee != null && bee != incomingBee) { return; } // Bee already present.
        
        bee = incomingBee;

        if(onBeeInteraction != null)
        {
            onBeeInteraction.Invoke();
        }

        if(autoTarget)
        {
            // Set current object as bee's target.
            bee.GetComponent<TargetManager>().Target = transform;
        }
    }
}
