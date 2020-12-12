﻿using System;
using UnityEngine;

public class DelayedAction : BasicAction
{
    private float currentTime;

    public DelayedAction(Action action, float delay) : base(action)
    {
        this.currentTime = delay;
    }

    public override void Run()
    {
        // Countdown to action.
        currentTime -= Time.deltaTime;
        if(currentTime < 0)
        {
            action();
            done = true;
        }
    }
}
