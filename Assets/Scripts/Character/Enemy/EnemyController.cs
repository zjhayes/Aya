using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterCombat))]
[RequireComponent(typeof(CharacterStats))]
[RequireComponent(typeof(Awareness))]
[RequireComponent(typeof(TargetManager))]
[RequireComponent(typeof(FaceTarget))]
public class EnemyController : MonoBehaviour, IController
{ 
    protected CharacterStats stats;
    protected CharacterCombat combat;
    protected Awareness awareness;
    protected TargetManager targetManager;
    protected Animator animator;
    protected FaceTarget faceTarget;
    protected StateContext<EnemyController> stateContext;

    public CharacterStats Stats { get { return stats; } }
    public CharacterCombat Combat { get { return combat; } }
    public Awareness Awareness { get { return awareness; } }
    public TargetManager TargetManager { get { return targetManager; } }
    public Animator Animator { get { return animator; } }
    public FaceTarget FaceTarget { get { return faceTarget; } }

    public virtual void Start()
    {
        animator = GetComponent<Animator>();
        stats = GetComponent<CharacterStats>();
        combat = GetComponent<CharacterCombat>();
        awareness = GetComponent<Awareness>();
        targetManager = GetComponent<TargetManager>();
        faceTarget = GetComponent<FaceTarget>();

        faceTarget.enabled = false;

        awareness.onAwarenessChanged += OnAwarenessChanged;
        stats.onDeath += Die;

        stateContext = new StateContext<EnemyController>(this);
    }

    private void OnAwarenessChanged()
    {
        if (awareness.IsAlert)
        {
            Alert();
        }
        else
        {
            Idle();
        }
    }

    protected virtual void Alert()
    {
        stateContext.Transition<CombatState>();
    }

    protected virtual void Idle()
    {
        stateContext.Transition<IdleState>();
    }

    private void Die()
    {
        stateContext.Transition<DeathState>();
    }
}