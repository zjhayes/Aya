using UnityEngine;

public class CharacterState<T> : MonoBehaviour, IState<T> where T : CharacterController
{
    protected T controller;

    public virtual void Destroy()
    {
        Destroy(this);
    }
}
