using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Attunable))]
public class CorruptRootController : EnemyController
{
    [SerializeField]
    private float idleSize = 0.5f;
    [SerializeField]
    private float alertSize = 1.0f;
    [SerializeField]
    private float sizeChangeRate = 3f; // Rate mesh changes size on state change.

    private Attunable attunable;
    
    public override void Start()
    {
        base.Start();

        attunable = GetComponent<Attunable>();
        
        attunable.onAttuned += Attune;

        TransformUtility.UpdateLocalScale(transform, idleSize);
    }

    protected override void Alert()
    {
        base.Alert();
        Grow();
    }

    protected override void Idle()
    {
        base.Idle();
        Shrink();
    }

    private void Shrink()
    {
        GradualAction shrink = new GradualAction(UpdateScale, transform.localScale.y, idleSize, sizeChangeRate);
        ActionManager.Instance.Add(shrink);
    }

    private void Grow()
    {
        GradualAction grow = new GradualAction(UpdateScale, transform.localScale.y, alertSize, sizeChangeRate);
        ActionManager.Instance.Add(grow);
    }

    private void UpdateScale(float newScale)
    {
        TransformUtility.UpdateLocalScale(transform, newScale);
    }
    
    private void Attune()
    {
        // Cause damage on attunement.
        CharacterStats targetStats = combat.TargetManager.Target.GetComponent<CharacterStats>();
        if(targetStats)
        {
            stats.TakeDamage(targetStats.Damage.Value);
        }
    }
}