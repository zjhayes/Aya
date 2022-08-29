using UnityEngine;

[RequireComponent(typeof(CharacterCombat))]
[RequireComponent(typeof(CharacterStats))]
public class EnemyController : CharacterController
{
    [SerializeField]
    protected Awareness awareness;
    [SerializeField]
    private float lookSpeed = 5f;

    protected CharacterStats stats;
    protected CharacterCombat combat;
    protected Animator animator;
    protected StateContext<EnemyController> stateContext;

    public CharacterStats Stats { get { return stats; } }
    public CharacterCombat Combat { get { return combat; } }
    public Awareness Awareness { get { return awareness; } }
    public Animator Animator { get { return animator; } }
    public float LookSpeed { get { return lookSpeed; } }

    public virtual void Start()
    {
        animator = GetComponent<Animator>();
        stats = GetComponent<CharacterStats>();
        combat = GetComponent<CharacterCombat>();

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