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

    Animator animator;
    Attunable attunable;
    Collider collider;
    bool isAttuned = false;
    bool isCharged = false;
    DelayedAction previousAction;

    public delegate void OnChargeUpdated(bool isCharged);
    public OnChargeUpdated onChargeUpdated;

    void Awake()
    {
        animator = GetComponent<Animator>();
        attunable = GetComponent<Attunable>();
        collider = GetComponent<BoxCollider>();
    }

    void Start()
    {
        animator.SetBool("IsAttuned", false);
        attunable.onAttuned += Attune;
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