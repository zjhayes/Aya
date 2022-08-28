using UnityEngine;

public class DeathState : CharacterState
{ 
    EnemyController controller;

    void Start()
    {
        controller = GetComponent<EnemyController>();
        Die();
    }

    private void Die()
    {
        controller.Animator.SetTrigger("isDead");
        controller.Awareness.IsAlert = false;
        controller.Awareness.enabled = false;
        controller.FaceTarget.enabled = false;
        controller.Combat.EnableDamage(false);
    }
}
