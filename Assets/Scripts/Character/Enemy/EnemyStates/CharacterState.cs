using UnityEngine;

public class CharacterState<T> : MonoBehaviour, IState<T> where T : CharacterController
{
    protected T controller;

    public virtual void Awake()
    {
        controller = GetComponent<T>();
        enabled = false; // Disable component by default.
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
