using UnityEngine;

public class TargetManager : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    public delegate void OnTargetChanged();
    public OnTargetChanged onTargetChanged;

    public Transform Target
    {
        get { return target; }
        set 
        { 
            this.target = value;
            if(onTargetChanged != null)
            {
                onTargetChanged.Invoke();
            }
        }
    }

    public void SetToPlayer()
    {
        target = PlayerManager.instance.Player.transform;
    }
}
