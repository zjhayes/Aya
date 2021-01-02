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
    private float destroyDelay = 10.0f;
    [SerializeField]
    private float autoWanderDelay = 3.0f;
    NavMeshAgent agent;
    private bool isWandering = false;
    private DelayedAction destroyAfterDelay;
    private Cooldown autoWanderCooldown;

    void Start()
    {
        GetComponent<BeeInteractable>().onBeeInteractable += Wander;
        agent = GetComponent<NavMeshAgent>();

        destroyAfterDelay = new DelayedAction(DestroyAfterDelay, destroyDelay);
        ActionManager.instance.Add(destroyAfterDelay);

        autoWanderCooldown = new Cooldown(autoWanderDelay);
        autoWanderCooldown.onCooldownReady += Wander;
    }

    private void Wander()
    {
        Vector3 randomDirection = Random.insideUnitSphere * moveRadius;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, moveRadius, 1);
        Vector3 movePosition = hit.position;
        agent.SetDestination(movePosition);
        autoWanderCooldown.Begin(); // Start new cooldown.
    }

    private void DestroyAfterDelay()
    {
        // End cooldown action.
        autoWanderCooldown.Cancel();

        // Destroy bee target.
        Destroy(gameObject);
    }
}
