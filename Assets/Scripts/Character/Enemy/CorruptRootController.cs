using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(CharacterCombat))]
[RequireComponent(typeof(CharacterStats))]
[RequireComponent(typeof(Awareness))]
[RequireComponent(typeof(Attunable))]
[RequireComponent(typeof(TargetManager))]
[RequireComponent(typeof(FaceTarget))]
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
    private CharacterCombat combat;
    private CharacterStats stats;
    private TargetManager targetManager;
    private Awareness awareness;
    private Attunable attunable;
    private DelayedAction previousAction;
    private TransformUtility objectScaler;
    private FaceTarget faceTarget;

    void Start()
    {
        animator = GetComponent<Animator>();
        combat = GetComponent<CharacterCombat>();
        stats = GetComponent<CharacterStats>();
        awareness = GetComponent<Awareness>();
        targetManager = GetComponent<TargetManager>();
        attunable = GetComponent<Attunable>();
        objectScaler = new TransformUtility(transform);
        faceTarget = GetComponent<FaceTarget>();

        targetManager.SetToPlayer();

        awareness.onAwarenessChanged += OnAwarenessChanged;
        attunable.onAttuned += Attune;
        stats.onDeath += Die;

        objectScaler.UpdateLocalScale(idleSize);
    }

    void Update()
    {
        if(!awareness.IsAlert || !TargetIsInRange())
        {
             // Should not be able to attack,
             // cancel current attacks.
            combat.CancelAttack();
        }
        else
        {
            AttackTarget();
        }
    }

    private void OnAwarenessChanged(bool isAlert)
    {
        if(isAlert)
        {
            if (previousAction != null) { previousAction.Cancel(); } // Stop previous action.
            Alert();
        }
        else
        {
            DelayedAction idleAfterDelay = new DelayedAction(Idle, idleDelay);
            ActionManager.Instance.Add(idleAfterDelay);
            previousAction = idleAfterDelay; // Store action, so it can be cancelled later.
        }

        // Toggle whether character faces target.
        faceTarget.enabled = isAlert;
    }

    private void Alert()
    {
        animator.SetBool("isAlert", true);
        Grow();
    }

    private void Idle()
    {
        if(!awareness.IsAlert) // Double-check alertness after idle delay.
        {
            animator.SetBool("isAlert", false);
            Shrink();
        }
    }

    private void Shrink()
    {
        GradualAction shrink = new GradualAction(objectScaler.UpdateLocalScale, transform.localScale.y, idleSize, sizeChangeRate);
        ActionManager.Instance.Add(shrink);
    }

    private void Grow()
    {
        GradualAction grow = new GradualAction(objectScaler.UpdateLocalScale, transform.localScale.y, alertSize, sizeChangeRate);
        ActionManager.Instance.Add(grow);
    }

    private void AttackTarget()
    {
        animator.SetTrigger("triggerAttack");
        CharacterStats targetStats = targetManager.Target.GetComponent<CharacterStats>();
        if(targetStats != null && TargetIsInRange())
        {
            combat.Attack(targetStats);
        }
    }
    
    private void Attune()
    {
        // Cause damage on attunement.
        CharacterStats targetStats = targetManager.Target.GetComponent<CharacterStats>();
        if(targetStats)
        {
            stats.TakeDamage(targetStats.Damage.Value);
        }
    }

    private void Die()
    {
        animator.SetTrigger("isDead");
        awareness.IsAlert = false;
        awareness.enabled = false;
        combat.CancelAttack();
    }

    private bool TargetIsInRange()
    {
        float distance = Vector3.Distance(targetManager.Target.position, transform.position);
        if(distance <= attackRadius)
        {
            return true;
        }
        return false;
    }

    private void OnDrawGizmosSelected() 
    {
        // Show enemy's visual radius in editor.
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}