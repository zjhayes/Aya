using System;
using UnityEngine;

public class Cooldown
{
    private float delay;
    private float cooldown = 0f;
    private DelayedAction cooldownAction;
    private bool isReady = true;

    public bool IsReady
    {
        get{ return isReady; }
    }

    public Cooldown(float delay)
    {
        this.delay = delay;
        this.cooldown = delay;
    }

    public void Begin()
    {
        if(isReady)
        {
            // Start new cooldown.
            isReady = false;
            cooldownAction = new DelayedAction(End, delay);
            ActionManager.instance.Add(cooldownAction);
        }
        else
        {
            // Restart current cooldown.
            Reset();
        }
    }

    public void Reset()
    {
        // Restart cooldown if current action exists.
        if(cooldownAction != null && !cooldownAction.IsDone())
        {
            cooldownAction.Reset();
        }
    }

    public void Cancel()
    {
        // Immediately ends current cooldown.
        if(cooldownAction != null && !cooldownAction.IsDone())
        {
            cooldownAction.Cancel();
            End();
        }
    }

    private void End()
    {
        isReady = true;
    }
}
