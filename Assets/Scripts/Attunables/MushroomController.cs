using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Attunable))]
[RequireComponent(typeof(Collider))]
public class MushroomController : MonoBehaviour
{
    [SerializeField]
    private float idleDelay = 5.0f;
    [SerializeField]
    private float bounceForce = 800.0f;
    private Animator animator;
    private Attunable attunable;
    private Collider collider;
    private bool isAttuned = false;
    private bool isCharged = false;
    DelayedAction previousAction;

    public delegate void OnChargeUpdated(bool isCharged);
    public OnChargeUpdated onChargeUpdated;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("IsAttuned", false);
        attunable = GetComponent<Attunable>();
        attunable.onAttuned += Attune;
        collider = GetComponent<BoxCollider>();
    }

    private void Attune()
    {
        if(!isAttuned)
        {
            isAttuned = true;
            isCharged = true;
            collider.isTrigger = false; // Enable collision.
            SetAnimation();
            // Resume idle state after delay.
            DelayedAction resumeIdle = new DelayedAction(Resume, idleDelay);
            ActionManager.Instance.Add(resumeIdle);
            previousAction = resumeIdle; // Store action.
            InvokeChargeUpdated();
        }
        else
        {
            Recharge();
        }
    }

    private void Resume()
    {
        isAttuned = false;
        isCharged = false;
        collider.isTrigger = true; // Disable collision.
        SetAnimation();
        InvokeChargeUpdated();
    }

    private void Recharge()
    {
        isCharged = true;
        // Reset Idle delay, if any.
        if(previousAction != null && !previousAction.IsDone()) { previousAction.Reset(); }
        InvokeChargeUpdated();
    }

    private void InvokeChargeUpdated()
    {
        if(onChargeUpdated != null)
        {
            onChargeUpdated.Invoke(isCharged);
        }
    }

    private void SetAnimation()
    {
        animator.SetBool("IsAttuned", isAttuned);
    }
}