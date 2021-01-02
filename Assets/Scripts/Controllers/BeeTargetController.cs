using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(BeeInteraction))]
[RequireComponent(typeof(NavMeshAgent))]
public class BeeTargetController : MonoBehaviour
{
    [SerializeField]
    private float moveRadius = 5.0f;
    [SerializeField]
    private float destroyDelay = 10.0f;
    NavMeshAgent agent;
    private bool isWandering = false;
    DelayedAction destroyAfterDelay;

    void Start()
    {
        GetComponent<BeeInteraction>().onBeeInteraction += Wander;
        agent = GetComponent<NavMeshAgent>();

        destroyAfterDelay = new DelayedAction(DestroyAfterDelay, destroyDelay);
        ActionManager.instance.Add(destroyAfterDelay);
    }

    private void Wander()
    {
        Vector3 randomDirection = Random.insideUnitSphere * moveRadius;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, moveRadius, 1);
        Vector3 movePosition = hit.position;
        agent.SetDestination(movePosition);
    }

    private void DestroyAfterDelay()
    {
        // If bee targeting this, destroy bee.
        //Destroy(GetComponent<BeeInteraction>().Bee);

        // Destroy bee target.
        Destroy(gameObject);
    }
}
