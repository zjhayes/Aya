using System.Collections.Generic;
using UnityEngine;
public class StateContext<T> where T : IController
{
    public IState<T> CurrentState
    {
        get; set;
    }

    private readonly T controller;

    public StateContext(T _controller)
    {
        controller = _controller;
    }

    public void Transition(IState<T> state)
    {
        if(CurrentState != null)
        {
            CurrentState.Disable();
        }

        CurrentState = state;
        CurrentState.Enable();
    }
}
