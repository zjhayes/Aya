using UnityEngine;

public class DeathState : CharacterState<EnemyController>
{
    public override void Enable()
    {
        base.Enable();
        Die();
    }

    protected virtual void Die()
    {
        controller.Animator.SetTrigger("isDead");
        controller.Awareness.IsAlert = false;
        controller.Awareness.enabled = false;
        controller.Combat.EnableDamage(false);
        if(GetComponent<Collider>() != null)
        {
            GetComponent<Collider>().enabled = false;
        }
    }
}
