using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(TargetManager))]
public class BeeController : MonoBehaviour
{
    [SerializeField]
    private Vector3 followOffset;

    private TargetManager targetManager;
    private NavMeshAgent agent;

    void Start()
    {
        this.targetManager = GetComponent<TargetManager>();
        targetManager.SetToPlayer();

        this.agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(targetManager.Target == null) 
        { 
            // No target, destroy.
            Dismiss();
            return;
        }

        Vector3 targetPosition = targetManager.Target.position;
        Vector3 destination = new Vector3(targetPosition.x + followOffset.x, targetPosition.y + followOffset.y, targetPosition.z + followOffset.z);
        if(destination != Vector3.zero)
        {
            agent.SetDestination(destination);
        }
    }

    private void Dismiss()
    {
        Destroy(gameObject);
    }
}
