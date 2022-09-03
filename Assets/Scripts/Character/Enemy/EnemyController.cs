using UnityEngine;


public class EnemyController : CharacterController
{
    [SerializeField]
    protected Awareness awareness;
    [SerializeField]
    private float lookSpeed = 5f;
    [SerializeField]
    protected IdleState idleState;
    [SerializeField]
    protected CombatState combatState;
    [SerializeField]
    protected DeathState deathState;

    protected StateContext<EnemyController> stateContext;

    public Awareness Awareness { get { return awareness; } }
    public float LookSpeed { get { return lookSpeed; } }

    public virtual void Awake()
    {
        animator = GetComponent<Animator>();
        stats = GetComponent<CharacterStats>();
        combat = GetComponent<CharacterCombat>();

        stateContext = new StateContext<EnemyController>(this);
    }

    public virtual void Start()
    {
        awareness.onAwarenessChanged += OnAwarenessChanged;
        stats.onDeath += Die;
        Idle();
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
        stateContext.Transition(combatState);
    }

    protected virtual void Idle()
    {
        stateContext.Transition(idleState);
    }

    protected virtual void Die()
    {
        stateContext.Transition(deathState);
    }
}