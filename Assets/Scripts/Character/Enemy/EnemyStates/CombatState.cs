using UnityEngine;

public class CombatState : CharacterState
{
    EnemyController controller;

    void Start()
    {
        controller = GetComponent<EnemyController>();
        controller.Animator.GetBehaviour<StateMachineEvent>().onStateEntered += OnAttackAnimationEnter; // Listen to Attack state.
        controller.Animator.GetBehaviour<StateMachineEvent>().onStateExited += OnAttackAnimationExit;
        controller.Animator.SetBool("isAlert", true);
        controller.FaceTarget.enabled = true;
    }

    void Update()
    {
        if (controller.TargetManager.HasTarget() && TargetIsInRange())
        {
            controller.Animator.SetTrigger("triggerAttack");
        }
    }

    private void OnAttackAnimationEnter()
    {
        controller.Combat.EnableDamage(true);
    }

    private void OnAttackAnimationExit()
    {
        controller.Combat.EnableDamage(false);
    }

    private bool TargetIsInRange()
    {
        float distance = Vector3.Distance(controller.TargetManager.Target.transform.position, transform.position);
        if (distance <= controller.Combat.AttackRadius)
        {
            return true;
        }
        return false;
    }
}
