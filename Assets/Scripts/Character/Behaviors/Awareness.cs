using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(TargetManager))]
public class Awareness : MonoBehaviour
{
    private bool isAlert;
    private TargetManager targetManager;
    private SphereCollider fieldOfView;

    public delegate void OnAwarenessChanged();
    public OnAwarenessChanged onAwarenessChanged;

    public bool IsAlert 
    { 
        get { return isAlert; }
        set 
        { 
            this.isAlert = value;
            if (onAwarenessChanged != null)
            {
                onAwarenessChanged.Invoke();
            }
        }
    }

    void Awake()
    {
        targetManager = GetComponent<TargetManager>();
        fieldOfView = GetComponent<SphereCollider>();
        fieldOfView.isTrigger = true;
        isAlert = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (targetManager.IsTaggedAsTarget(other.gameObject))
        {
            targetManager.Target = other.gameObject;
            IsAlert = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(GameObject.ReferenceEquals(other.gameObject, targetManager.Target))
        {   // Collider is current target..
            IsAlert = false;
            targetManager.Target = null;
        }
    }

    void OnEnable()
    {
        fieldOfView.enabled = true;
    }

    void OnDisable()
    {
        fieldOfView.enabled = false;
    }
}