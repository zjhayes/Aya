using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TargetManager))]
[RequireComponent(typeof(SphereCollider))]
public class Awareness : MonoBehaviour
{
    [SerializeField]
    private List<string> targetTags;

    private bool isAlert;
    private TargetManager targetManager;

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

    void Start()
    {
        targetManager = GetComponent<TargetManager>();
        GetComponent<SphereCollider>().isTrigger = true;
        isAlert = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (targetTags.Contains(other.gameObject.tag))
        {
            IsAlert = true;
            targetManager.Target = other.gameObject.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == targetManager.Target)
        {
            IsAlert = false;
            targetManager.Target = null;
        }
    }
}