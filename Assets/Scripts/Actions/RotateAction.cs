using System;
using UnityEngine;

public class RotateAction : IAction
{
    Action<Quaternion> action;
    Quaternion currentRotation;
    Quaternion targetRotation;
    float rate;
    bool done;
    float currentTime = 0;

    public RotateAction(Action<Quaternion> action, Quaternion originalRotation, Quaternion targetRotation, float rate)
    {
        this.action = action;
        this.currentRotation = originalRotation;
        this.targetRotation = targetRotation;
        this.rate = rate;
        this.done = false;
    }

    public void Run()
    {
        currentRotation = Quaternion.RotateTowards(currentRotation, targetRotation, rate);
        action(currentRotation);
        if (currentRotation == targetRotation) { done = true; }
    }

    public bool IsDone()
    {
        return done;
    }

    public void Cancel()
    {
        done = true;
    }
}
