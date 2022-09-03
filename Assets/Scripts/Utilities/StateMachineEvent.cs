using UnityEngine;

public class StateMachineEvent : StateMachineBehaviour
{
    public delegate void OnStateEntered();
    public OnStateEntered onStateEntered;

    public delegate void OnStateExited();
    public OnStateExited onStateExited;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (onStateEntered != null)
        {
            onStateEntered.Invoke();
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (onStateExited != null)
        {
            onStateExited.Invoke();
        }
    }
}
