using UnityEngine;

[RequireComponent(typeof(Awareness))]
public class Follow : MonoBehaviour
{
    [SerializeField]
    private bool faceTarget = true;
    [SerializeField]
    private float lookSpeed = 5f;

    private Awareness awareness;

    void Start()
    {
        awareness = GetComponent<Awareness>();
    }

    void Update()
    {
        if(awareness.IsAlert && faceTarget)
        {
            FaceTarget();
        }
    }

    private void FaceTarget()
    {
        Quaternion lookRotation = LookRotationToTarget();
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * lookSpeed);
    }

    public Quaternion LookRotationToTarget()
    {
        if(awareness.Target == null) 
        { 
            Debug.LogError(transform.name + " does not have a target.");
            return new Quaternion(); 
        }
        Vector3 direction = (awareness.Target.position - transform.position).normalized;
        return Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
    }
}