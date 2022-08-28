using UnityEngine;

public class CharacterState : MonoBehaviour, IState<EnemyController>
{
    public virtual void Destroy()
    {
        Destroy(this);
    }
}
