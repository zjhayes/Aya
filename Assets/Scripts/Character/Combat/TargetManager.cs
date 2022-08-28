using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    [SerializeField]
    private List<string> targetTags;
    [SerializeField]
    private GameObject target;

    public delegate void OnTargetChanged();
    public OnTargetChanged onTargetChanged;

    public GameObject Target
    {
        get { return target; }
        set 
        {
            this.target = value;
            InvokeOnTargetChanged();
        }
    }

    private void InvokeOnTargetChanged()
    {
        if(onTargetChanged != null)
        {
            onTargetChanged.Invoke();
        }
    }

    public bool IsTaggedAsTarget(GameObject other)
    {
        if (targetTags.Contains(other.tag))
        {
            return true;
        }
        return false;
    }

    public bool HasTarget()
    {
        return target != null;
    }
}
