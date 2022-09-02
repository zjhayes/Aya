using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Attunable))]
public class CorruptRootController : EnemyController
{
    private Attunable attunable;
    
    public override void Awake()
    {
        base.Awake();

        attunable = GetComponent<Attunable>();
        
        attunable.onAttuned += Attune;
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