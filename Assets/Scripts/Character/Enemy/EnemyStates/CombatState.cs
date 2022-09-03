using UnityEngine;

public class CombatState : CharacterState<EnemyController>
{
    void Start()
    {
        controller.Animator.GetBehaviour<StateMachineEvent>().onStateEntered += OnAttackAnimationEnter; // Listen to Attack state.
        controller.Animator.GetBehaviour<StateMachineEvent>().onStateExited += OnAttackAnimationExit;
    }

    public override void Enable()
    {
        base.Enable();
        controller.Animator.SetBool("isAlert", true);
    }

    public virtual void Update()
    {
        FaceTarget();
        if (controller.Combat.TargetManager.HasTarget() && TargetIsInRange())
        {
            controller.Animator.SetTrigger("triggerAttack");
        }
    }

    private void OnAttackAnimationEnter()
    {
        // Enable damaage while attacking.
        controller.Combat.EnableDamage(true);
    }

    private void OnAttackAnimationExit()
    {
        // Disable damage after attack animation.
        controller.Combat.EnableDamage(false);
    }

    private bool TargetIsInRange()
    {
        float distance = Vector3.Distance(controller.Combat.TargetManager.Target.transform.position, transform.position);
        if (distance <= controller.Combat.AttackRadius)
        {
            return true;
        }
        return false;
    }

    public void FaceTarget()
    {
        Quaternion lookRotation = LookRotationToTarget();
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * controller.LookSpeed);
    }

    private Quaternion LookRotationToTarget()
    {
        Quaternion lookRotation = transform.rotation;

        if (controller.Combat.TargetManager.Target != null)
        {
            Vector3 direction = (controller.Combat.TargetManager.Target.transform.position - transform.position).normalized;
            Vector3 rotation = new Vector3(direction.x, 0, direction.z);
            if (rotation != Vector3.zero)
            {
                lookRotation = Quaternion.LookRotation(rotation);
            }
        }
        else
        {
            Debug.LogError(transform.name + " does not have a target.");
        }

        return lookRotation;
    }
}
