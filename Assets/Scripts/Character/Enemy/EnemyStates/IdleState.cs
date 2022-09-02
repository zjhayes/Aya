using UnityEngine;

public class IdleState : CharacterState<EnemyController>
{
    DelayedAction previousAction;

    void Start()
    {
        controller = GetComponent<EnemyController>();

        // Run delay before idle.
        DelayedAction idleAfterDelay = new DelayedAction(Idle, controller.Combat.IdleDelay);
        ActionManager.Instance.Add(idleAfterDelay);
        previousAction = idleAfterDelay; // Store action, so it can be cancelled later.
    }

    protected virtual void Idle()
    {
        // Set idle animation.
        controller.Animator.SetBool("isAlert", false);
    }

    public override void Destroy()
    {
        // Stop idle delay, if running.
        previousAction.Cancel();
        base.Destroy();
    }
}
