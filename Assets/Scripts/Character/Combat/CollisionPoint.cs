using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CollisionPoint : MonoBehaviour
{
    public delegate void OnCollisionPointEnter(GameObject other);
    public OnCollisionPointEnter onCollisionPointEnter;

    private void OnTriggerEnter(Collider other)
    {
        InvokeOnCollision(other.gameObject);
    }

    private void InvokeOnCollision(GameObject other)
    {
        if (onCollisionPointEnter != null)
        {
            onCollisionPointEnter.Invoke(other);
        }
    }
}
