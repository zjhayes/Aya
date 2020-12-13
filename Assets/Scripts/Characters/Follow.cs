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
        Vector3 direction = (awareness.Target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * lookSpeed);
    }
}