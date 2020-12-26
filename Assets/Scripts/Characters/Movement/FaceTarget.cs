using UnityEngine;

public class FaceTarget
{
    private Transform transform;
    private Transform target;
    private float lookSpeed = 5f;

    public Transform Target 
    { 
        get { return target; } 
        set { this.target = value; }
    }

    public FaceTarget(Transform transform)
    {
        this.transform = transform;
    }

    public float LookSpeed
    {
        get { return lookSpeed; }
        set { this.lookSpeed = value; }
    }

    public void Look()
    {
        Quaternion lookRotation = LookRotationToTarget();
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * lookSpeed);
    }

    public Quaternion LookRotationToTarget()
    {
        if(target == null) 
        { 
            Debug.LogError(transform.name + " does not have a target.");
            return new Quaternion(); 
        }
        Vector3 direction = (target.position - transform.position).normalized;
        return Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
    }
}
