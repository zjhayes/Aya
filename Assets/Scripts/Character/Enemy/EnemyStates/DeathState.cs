using UnityEngine;

public class DeathState : CharacterState<EnemyController>
{
    void Enable()
    {
        Die();
    }

    private void Die()
    {
        controller.Animator.SetTrigger("isDead");
        controller.Awareness.IsAlert = false;
        controller.Awareness.enabled = false;
        controller.Combat.EnableDamage(false);
    }
}
