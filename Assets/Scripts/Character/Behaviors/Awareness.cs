﻿using UnityEngine;

[RequireComponent(typeof(TargetManager))]
[RequireComponent(typeof(SphereCollider))]
public class Awareness : MonoBehaviour
{
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
        if (targetManager.IsTaggedAsTarget(other.gameObject))
        {
            targetManager.Target = other.gameObject;
            IsAlert = true;
        }
    }

    /*private void OnTriggerExit(Collider other)
    {
        if(GameObject.ReferenceEquals(other.gameObject, targetManager.Target))
        {
            IsAlert = false;
            targetManager.Target = null;
        }
    }*/
}