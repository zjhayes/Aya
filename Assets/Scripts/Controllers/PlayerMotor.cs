using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    private Transform target;
    private NavMeshAgent agent;
    private float rotationSpeed = 5f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(target != null)
        {
            agent.SetDestination(target.position);
            FaceTarget();
        }
    }

    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }

    public void FollowTarget(Interactable newTarget)
    {
        agent.stoppingDistance = newTarget.Radius * .8f;
        agent.updateRotation = false;
        target = newTarget.InteractionTransform;
    }

    public void StopFollowingTarget()
    {
        agent.stoppingDistance = 0;
        agent.updateRotation = true;
        target = null;
    }

    // Rotate player to face target.
    private void FaceTarget()
    {
        Vector3 direction = CalculateDirectionOfTarget();
        Quaternion lookRotation = CalculateLookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }

    // Calculate the direction of the target in reference to the player.
    private Vector3 CalculateDirectionOfTarget()
    {
        return (target.position - transform.position).normalized;
    }

    // Calculate the rotation of the player required to face the target.
    private Quaternion CalculateLookRotation(Vector3 directionOfTarget)
    {
        return Quaternion.LookRotation(new Vector3(directionOfTarget.x, 0f, directionOfTarget.z));
    }
}
