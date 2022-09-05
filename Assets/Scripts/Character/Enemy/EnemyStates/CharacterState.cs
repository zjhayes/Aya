using UnityEngine;

public class CharacterState<T> : MonoBehaviour, IState<T> where T : CharacterController
{
    protected T controller;

    protected virtual void Awake()
    {
        controller = GetComponent<T>();
        enabled = false;
    }

    public virtual void Enable()
    {
        enabled = true;
    }

    public virtual void Disable()
    {
        enabled = false;
    }
}
