using System;
using UnityEngine;

public class MoveAction : IAction
{
    Transform movable;
    Vector3 targetPosition;
    float rate;
    bool done;
    float currentTime = 0;

    public MoveAction(Transform movable, Vector3 targetPosition, float rate)
    {
        this.movable = movable;
        this.targetPosition = targetPosition;
        this.rate = rate;
        this.done = false;
    }

    public void Run()
    {
        currentTime += Time.deltaTime / rate;
        movable.position = Vector3.MoveTowards(movable.position, targetPosition, currentTime);
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
