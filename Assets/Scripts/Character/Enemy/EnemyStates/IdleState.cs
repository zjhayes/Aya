using UnityEngine;

public class IdleState : CharacterState<EnemyController>
{
    DelayedAction previousAction;

    public override void Enable()
    {
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

    public override void Disable()
    {
        // Stop idle delay, if running.
        if(previousAction != null)
        {
            previousAction.Cancel();
        }
        base.Disable();
    }
}
