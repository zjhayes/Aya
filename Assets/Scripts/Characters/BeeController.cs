using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class BeeController : MonoBehaviour
{
    [SerializeField]
    private Vector3 followOffset;
    private Transform target;
    private UnityEngine.AI.NavMeshAgent agent;
    private FaceTarget facing;

    void Start()
    {
        this.target = PlayerManager.instance.Player.transform;
        this.agent = GetComponent<NavMeshAgent>();
        this.facing =  new FaceTarget(transform);
        facing.Target = PlayerManager.instance.Player.transform;
    }

    void Update()
    {
        Vector3 destination = new Vector3(target.position.x + followOffset.x, target.position.y + followOffset.y, target.position.z + followOffset.z);
        if(destination != Vector3.zero)
        {
            agent.SetDestination(destination);
        }
        facing.Look();
    }
}
