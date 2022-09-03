using UnityEngine;

[RequireComponent(typeof(TargetManager))]
public class FaceTarget : MonoBehaviour /* DEPRECATED */
{
    [SerializeField]
    private float lookSpeed = 5f;
    
    private TargetManager targetManager;

    void Start()
    {
       targetManager = GetComponent<TargetManager>();
    }

    void Update()
    {
        Look();
    }

    public void Look()
    {
        Quaternion lookRotation = LookRotationToTarget();
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * lookSpeed);
    }

    private Quaternion LookRotationToTarget()
    {
        Quaternion lookRotation = transform.rotation;

        if(targetManager.Target != null) 
        { 
            Vector3 direction = (targetManager.Target.transform.position - transform.position).normalized;
            Vector3 rotation = new Vector3(direction.x, 0, direction.z);
            if(rotation != Vector3.zero)
            {
                lookRotation = Quaternion.LookRotation(rotation);
            }
        }
        else
        {
            Debug.LogError(transform.name + " does not have a target.");
        }

        return lookRotation;
    }
}