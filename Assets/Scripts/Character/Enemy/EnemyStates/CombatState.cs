using UnityEngine;

public class CombatState : MonoBehaviour, IState<EnemyController>
{
    EnemyController controller;

    void Start()
    {
        controller = GetComponent<EnemyController>();
        controller.Animator.GetBehaviour<StateMachineEvent>().onStateEntered += OnAttackAnimationEnter;
        controller.Animator.GetBehaviour<StateMachineEvent>().onStateExited += OnAttackAnimationExit;
    }

    void Update()
    {
        if (controller.TargetManager.HasTarget() && TargetIsInRange())
        {
            controller.Attack();
        }
    }

    private void OnAttackAnimationEnter()
    {
        controller.EnableDamage(true);
    }

    private void OnAttackAnimationExit()
    {
        controller.EnableDamage(false);
    }

    private bool TargetIsInRange()
    {
        float distance = Vector3.Distance(controller.TargetManager.Target.transform.position, transform.position);
        if (distance <= controller.AttackRadius)
        {
            return true;
        }
        return false;
    }

    private void OnDrawGizmosSelected()
    {
        // Show enemy's visual radius in editor.
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, controller.AttackRadius);
    }

    public void Destroy()
    {
        Destroy(this);
    }
}
