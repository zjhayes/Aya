using UnityEngine;

[RequireComponent(typeof(CharacterCombat))]
[RequireComponent(typeof(CharacterStats))]
public class WanderingThistleController : MonoBehaviour
{
    [SerializeField]
    private GameObject head;

    CharacterCombat combat;
    CharacterStats stats;
    Animator animator;
    Awareness awareness;
    TargetManager target;
    FaceTarget faceTarget;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float lookRadius = 10f;
    [SerializeField]
    private float lookSpeed = 5f;

    Transform target;
    NavMeshAgent agent;
    CharacterCombat combat;

    void Start()
    {
        target = PlayerManager.Instance.Player.transform; // Track player's location.
        agent = GetComponent<NavMeshAgent>();
        combat = GetComponent<CharacterCombat>();
    }

    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            // Chase player.
            agent.SetDestination(target.position);

            // If enemy is in range...
            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();

                // Attack target.
                CharacterStats targetStats = target.GetComponent<CharacterStats>();
                if (targetStats != null)
                {
                    combat.Attack(targetStats);
                }
            }
        }
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * lookSpeed);
    }

    private void OnDrawGizmosSelected()
    {
        // Show enemy's visual radius in editor.
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}*/
