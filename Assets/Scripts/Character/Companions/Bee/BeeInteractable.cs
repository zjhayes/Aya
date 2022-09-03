using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class BeeInteractable : MonoBehaviour
{
    [SerializeField]
    private bool autoTarget = true;
    [SerializeField]
    private bool beeSwap = false;
    [SerializeField]
    private bool enabled = true;

    private GameObject bee;

    public bool IsEnabled
    {
        get{ return enabled; }
        set{ this.enabled = value; }
    }

    public delegate void OnBeeInteractable();
    public OnBeeInteractable onBeeInteractable;


    public GameObject Bee
    {
        get{ return bee; }
    }

    public void Interact(GameObject incomingBee)
    {
        if(!enabled || (bee != null && bee != incomingBee && !beeSwap)) 
        {
            return; // Iteraction disabled, or bee already present.
        }
        
        bee = incomingBee;

        if(onBeeInteractable != null)
        {
            onBeeInteractable.Invoke();
        }

        if(autoTarget)
        {
            // Set current object as bee's target.
            bee.GetComponent<TargetManager>().Target = gameObject;
        }
    }
}
