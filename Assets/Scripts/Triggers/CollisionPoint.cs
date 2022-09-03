using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CollisionPoint : MonoBehaviour
{
    public delegate void OnCollisionPointEnter(GameObject other);
    public OnCollisionPointEnter onCollisionPointEnter;

    Collider collider;

    void Awake()
    {
        collider = GetComponent<Collider>();
    }

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

    void OnEnable()
    {
        collider.enabled = true;
    }

    void OnDisable()
    {
        collider.enabled = false;
    }
}
