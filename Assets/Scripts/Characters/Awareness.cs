using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(TargetManager))]
public class Awareness : MonoBehaviour
{
    [SerializeField]
    private float lookRadius = 10f;

    private bool isAlert;
    private TargetManager targetManager;

    public bool IsAlert 
    { 
        get { return isAlert; }
        set { this.isAlert = value; }
    }

    public delegate void OnAwarenessChanged(bool isAlert);
    public OnAwarenessChanged onAwarenessChanged;

    void Start()
    {
        targetManager = GetComponent<TargetManager>();
        isAlert = false;
    }

    void Update()
    {
        if(targetManager.Target != null)
        {
            // Determine whether target is in look radius.
            float distance = Vector3.Distance(targetManager.Target.position, transform.position);
            bool targetInView = (distance <= lookRadius);
            // Does alertness need to be updated?
            if(targetInView != isAlert)
            {
                isAlert = targetInView;
                if(onAwarenessChanged != null)
                {
                    onAwarenessChanged.Invoke(isAlert);
                }
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