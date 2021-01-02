using UnityEngine;

[RequireComponent(typeof(TargetManager))]
public class FaceTarget : MonoBehaviour
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
        if(targetManager.Target != null)
        {
            Look();
        }
    }

    public void Look()
    {
        Quaternion lookRotation = LookRotationToTarget();
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * lookSpeed);
    }

    private Quaternion LookRotationToTarget()
    {
        if(targetManager.Target == null) 
        { 
            Debug.LogError(transform.name + " does not have a target.");
            return new Quaternion(); 
        }
        Vector3 direction = (targetManager.Target.position - transform.position).normalized;
        return Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
    }
}
