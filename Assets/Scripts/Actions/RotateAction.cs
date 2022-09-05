using System;
using UnityEngine;

public class RotateAction : IAction
{
    Transform rotatable;
    Quaternion targetRotation;
    float rate;
    bool done;
    float currentTime = 0;

    public RotateAction(Transform movable, Quaternion targetRotation, float rate)
    {
        this.rotatable = movable;
        this.targetRotation = targetRotation;
        this.rate = rate;
        this.done = false;
    }

    public void Run()
    {
        currentTime += Time.deltaTime / rate;
        rotatable.rotation = Quaternion.RotateTowards(rotatable.rotation, targetRotation, currentTime);
        if (currentTime >= 1) { done = true; }
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
