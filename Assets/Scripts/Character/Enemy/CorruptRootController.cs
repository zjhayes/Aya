using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Attunable))]
public class CorruptRootController : EnemyController
{
    private Attunable attunable;
    
    public override void Start()
    {
        base.Start();

        attunable = GetComponent<Attunable>();
        
        attunable.onAttuned += Attune;

        Idle();
    }

    protected override void Idle()
    {
        stateContext.Transition<ShrunkIdleState>();
    }

    protected override void Alert()
    {
        base.Alert();
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