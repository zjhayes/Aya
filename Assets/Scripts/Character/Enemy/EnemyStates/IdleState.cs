using UnityEngine;

public class IdleState : CharacterState
{
    EnemyController controller;
    DelayedAction previousAction;

    void Start()
    {
        controller = GetComponent<EnemyController>();

        // Run delay before idle.
        DelayedAction idleAfterDelay = new DelayedAction(Idle, controller.Combat.IdleDelay);
        ActionManager.Instance.Add(idleAfterDelay);
        previousAction = idleAfterDelay; // Store action, so it can be cancelled later.
    }

    void Idle()
    {
        controller.Animator.SetBool("isAlert", false);
    }

    public override void Destroy()
    {
        previousAction.Cancel();
        base.Destroy();
    }
}
