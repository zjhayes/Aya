using UnityEngine;

public class OnCollisionListener : MonoBehaviour
{
    [SerializeField]
    private string colliderTag = "Terrain";

    public delegate void OnCollisionEntered();
    public OnCollisionEntered onCollisionEntered;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals(colliderTag))
        {
            onCollisionEntered?.Invoke();
        }
    }
}
