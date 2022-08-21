using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyManager : MonoBehaviour
{
    Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
    }

    public Vector3 Velocity
    {
        get { return rigidbody.velocity; }

        set { rigidbody.velocity = value; }
    }

    public Vector3 Position
    {
        get { return rigidbody.position; }

        set { rigidbody.position = value; }
    }

    public void AddForce(Vector3 force)
    {
        rigidbody.AddForce(force);
    }
}
