using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Awareness : MonoBehaviour
{

    [SerializeField]
    private string targetTag;
    [SerializeField]
    private float lookRadius = 10f;

    private bool isAlert;
    private bool enabled = true;
    private Transform target;

    public bool IsAlert 
    { 
        get { return isAlert; }
        set { this.isAlert = value; }
    }

    public bool Enabled 
    {
        get { return enabled; }
        set { this.enabled = value; }
    }

    public Transform Target 
    { 
        get { return target; } 
        set { this.target = value; }
    }

    public delegate void OnAwarenessChanged(bool isAlert);
    public OnAwarenessChanged onAwarenessChanged;

    void Start()
    {
        target = GameObject.FindWithTag(targetTag).transform;
        isAlert = false;
    }

    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        bool targetInView = (distance <= lookRadius);
        // Does alertness need to be updated?
        if(enabled && targetInView != isAlert)
        {
            isAlert = targetInView;
            if(onAwarenessChanged != null)
            {
                onAwarenessChanged.Invoke(isAlert);
            }
        }
    }

    private void OnDrawGizmosSelected() 
    {
        // Show look radius.
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}