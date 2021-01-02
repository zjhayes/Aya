using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(BeeInteractable))]
[RequireComponent(typeof(NavMeshAgent))]
public class BeeTargetController : MonoBehaviour
{
    [SerializeField]
    private float moveRadius = 5.0f;
    [SerializeField]
    private float destroyDelay = 5.0f;
    NavMeshAgent agent;
    private bool isWandering = false;
    DelayedAction destroyAfterDelay;

    void Start()
    {
        GetComponent<BeeInteractable>().onBeeInteractable += Wander;
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
        destroyAfterDelay.Reset(); // Restart countdown to object destroy.
    }

    private void DestroyAfterDelay()
    {
        // Destroy bee target.
        Destroy(gameObject);
    }
}
