using System;
using UnityEngine;

public class MoveAction : IAction
{
    Action<Vector3> action;
    Vector3 currentPosition;
    Vector3 targetPosition;
    float rate;
    bool done;
    float currentTime = 0;

    public MoveAction(Action<Vector3> action, Vector3 originalPosition, Vector3 targetPosition, float rate)
    {
        this.action = action;
        this.currentPosition = originalPosition;
        this.targetPosition = targetPosition;
        this.rate = rate;
        this.done = false;
    }

    public void Run()
    {
        currentPosition = Vector3.MoveTowards(currentPosition, targetPosition, rate);
        action(currentPosition);
        if (currentPosition == targetPosition) { done = true; }
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
