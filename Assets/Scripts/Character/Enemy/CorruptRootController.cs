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
public class CorruptRootController : EnemyController
{
    [SerializeField]
    private float lookSpeed = 5f;
    [SerializeField]
    private float idleDelay = 3f; // Time before returning to idle state.
    [SerializeField]
    private float idleSize = 0.5f;
    [SerializeField]
    private float alertSize = 1.0f;
    [SerializeField]
    private float sizeChangeRate = 3f; // Rate mesh changes size on state change.

    private CharacterCombat combat;
    private CharacterStats stats;
    private Awareness awareness;
    private Attunable attunable;
    private DelayedAction previousAction;
    private TransformUtility objectScaler;
    private FaceTarget faceTarget;
    private bool isDead = false;

    StateContext<EnemyController> stateContext;

    public Awareness Awareness { get; }
    public CharacterCombat Combat { get; }
    public CharacterStats Stats { get; }


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

        faceTarget.enabled = false;

        awareness.onAwarenessChanged += OnAwarenessChanged;
        attunable.onAttuned += Attune;
        stats.onDeath += Die;

        objectScaler.UpdateLocalScale(idleSize);

        stateContext = new StateContext<EnemyController>(this);
        SetDamagePointListeners();
    }

    private void SetDamagePointListeners()
    {
        foreach(CollisionPoint damagePoint in damagePoints)
        {
            damagePoint.onCollisionPointEnter += OnDamagePointEnter;
        }
        EnableDamage(false);
    }




    /*
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
    }*/

    private void OnAwarenessChanged()
    {
        if(awareness.IsAlert)
        {
            if (previousAction != null) { previousAction.Cancel(); } // Stop previous action.
            OnAlert();
        }
        else
        {
            DelayedAction idleAfterDelay = new DelayedAction(AfterIdle, idleDelay);
            ActionManager.Instance.Add(idleAfterDelay);
            previousAction = idleAfterDelay; // Store action, so it can be cancelled later.
        }

        // Toggle whether character faces target.
        faceTarget.enabled = awareness.IsAlert;
    }

    private void OnAlert()
    {
        stateContext.Transition<CombatState>();
        animator.SetBool("isAlert", true);
        Grow();
    }

    private void AfterIdle()
    {
        animator.SetBool("isAlert", false);
        Shrink();
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

    public override void Attack()
    {
        animator.SetTrigger("triggerAttack");
    }

    private void OnDamagePointEnter(GameObject other)
    {
        if (targetManager.IsTaggedAsTarget(other))
        {
            DamageTarget();
        }
    }

    private void DamageTarget()
    {
        CharacterStats targetStats = targetManager.Target.GetComponent<CharacterStats>();
        if (targetStats != null)
        {
            combat.Attack(targetStats);
        }
    }
    
    private void Attune()
    {
        // Cause damage on attunement.
        CharacterStats targetStats = targetManager.Target.GetComponent<CharacterStats>();
        if(!isDead && targetStats)
        {
            stats.TakeDamage(targetStats.Damage.Value);
        }
    }

    private void Die()
    {
        isDead = true;
        animator.SetTrigger("isDead");
        awareness.IsAlert = false;
        awareness.enabled = false;
        faceTarget.enabled = false;
        combat.CancelAttack();
        EnableDamage(false);
    }
}