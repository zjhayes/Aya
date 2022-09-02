using UnityEngine;

public class ShrunkIdleState : IdleState
{
    [SerializeField]
    private float idleSize = 0.5f;
    [SerializeField]
    private float alertSize = 1.0f;
    [SerializeField]
    private float sizeChangeRate = 3f; // Rate mesh changes size on state change.

    public float IdleSize { get { return idleSize; } }
    public float AlertSize { get { return alertSize; } }
    public float SizeChangeRate { get { return sizeChangeRate; } }

    protected override void Idle()
    {
        controller.Animator.SetBool("isAlert", false);
        Shrink();
    }

    private void Shrink()
    {
        GradualAction shrink = new GradualAction(UpdateScale, transform.localScale.y, IdleSize, SizeChangeRate);
        ActionManager.Instance.Add(shrink);
    }

    private void Grow()
    {
        GradualAction grow = new GradualAction(UpdateScale, transform.localScale.y, AlertSize, SizeChangeRate);
        ActionManager.Instance.Add(grow);
    }


    private void UpdateScale(float newScale)
    {
        TransformUtility.UpdateLocalScale(transform, newScale);
    }

    public override void Destroy()
    {
        Grow();
        base.Destroy();
    }
}