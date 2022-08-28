using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CollisionPoint : MonoBehaviour
{
    public delegate void OnCollisionPointEnter(GameObject other);
    public OnCollisionPointEnter onCollisionPointEnter;

    [SerializeField]
    private bool active = true;

    public bool Active 
    { 
        get { return active; } 
        set { active = value; }
    }

    private void OnTriggerEnter(Collider other)
    {
        InvokeOnCollision(other.gameObject);
    }

    private void InvokeOnCollision(GameObject other)
    {
        if (active && onCollisionPointEnter != null)
        {
            onCollisionPointEnter.Invoke(other);
        }
    }
}
