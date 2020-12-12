using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterCombat))]
public class CorruptRootController : MonoBehaviour
{
    [SerializeField]
    private float lookSpeed = 5f;
    [SerializeField]
    private float attackRadius = 2f;
    [SerializeField]
    private float idleDelay = 3f; // Time before returning to idle state.
    [SerializeField]
    private float idleSize = 0.5f;
    [SerializeField]
    private float alertSize = 1.0f;
    [SerializeField]
    private float sizeChangeRate = 3f; // Rate mesh changes size on state change.

    private Animator animator;
    private Transform target;
    private UnityEngine.AI.NavMeshAgent agent;
    private CharacterCombat combat;

    void Start()
    {
        animator = GetComponent<Animator>();
        combat = GetComponent<CharacterCombat>();
    }

    void Update()
    {
        // If aggroed...
        if(target != null)
        {
            FaceTarget();

            float distance = Vector3.Distance(target.position, transform.position);
            // If target is in attack range...
            if(distance <= attackRadius)
            {
                AttackTarget();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Alert(other.transform);
    }

    void OnTriggerExit(Collider other)
    {
        DelayedAction idleAfterDelay = new DelayedAction(Idle, idleDelay);
        ActionManager.instance.Add(idleAfterDelay);
    }

    private void Alert(Transform target)
    {
        this.target = target;
        animator.SetBool("isAggroed", true);
        Grow();
    }

    private void Idle()
    {
        this.target = null;
        animator.SetBool("isAggroed", false);
        Shrink();
    }

    private void Shrink()
    {
        GradualAction shrink = new GradualAction(UpdateMeshSize, alertSize, idleSize, sizeChangeRate);
        ActionManager.instance.Add(shrink);
    }

    private void Grow()
    {
        GradualAction grow = new GradualAction(UpdateMeshSize, idleSize, alertSize, sizeChangeRate);
        ActionManager.instance.Add(grow);
    }

    private void UpdateMeshSize(float newScale)
    {
        transform.localScale = new Vector3(newScale, newScale, newScale);
    }

    private void AttackTarget()
    {
        animator.SetTrigger("triggerAttack");
        CharacterStats targetStats = target.GetComponent<CharacterStats>();
        if(targetStats != null)
        {
            combat.Attack(targetStats);
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
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
