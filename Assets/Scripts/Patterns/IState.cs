using UnityEngine;

public interface IState<T> where T : IController
{
    void Destroy();
}
