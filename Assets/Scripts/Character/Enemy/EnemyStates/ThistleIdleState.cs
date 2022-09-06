using System;
using UnityEngine;

[RequireComponent(typeof(StemManager))]
public class ThistleIdleState : IdleState
{
    [SerializeField]
    private float retractSpeed = 5.0f;
    StemManager stem;
    OngoingAction retractStemAction;

    protected override void Awake()
    {
        base.Awake();
        stem = GetComponent<StemManager>();
    }

    public override void Idle()
    {
        base.Idle();
        retractStemAction?.Cancel();
        retractStemAction = new OngoingAction(RetractStemToBase);
        ActionManager.Instance.Add(retractStemAction);
    }

    private void RetractStemToBase()
    {
        if (!stem.IsRetracting())
        {
            // Manually end action when fully retracted.
            if (stem.StemPoints.Count <= 0)
            {
                retractStemAction.Cancel();
            }

            stem.RetractStem(retractSpeed);
        }
    }   

    public override void Disable()
    {
        base.Disable();
        retractStemAction?.Cancel();
    }
}
