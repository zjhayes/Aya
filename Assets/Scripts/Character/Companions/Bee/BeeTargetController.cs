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
    private NavMeshAgent agent;
    private bool isWandering = false;
    private DelayedAction destroyAfterDelay;
    private Cooldown autoWanderCooldown;
    private BeeInteractable beeInteract;

    void Start()
    {
        beeInteract = GetComponent<BeeInteractable>();
        beeInteract.onBeeInteractable += Wander;
        agent = GetComponent<NavMeshAgent>();

        destroyAfterDelay = new DelayedAction(DestroyAfterDelay, destroyDelay);
        ActionManager.Instance.Add(destroyAfterDelay);

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
        // If destroy action in progress, cancel.
        if(!destroyAfterDelay.IsDone()) { destroyAfterDelay.Cancel(); }

        // End cooldown action.
        autoWanderCooldown.Cancel();

        // Destroy bee target.
        Destroy(gameObject);
    }
}
