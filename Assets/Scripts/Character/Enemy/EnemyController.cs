using UnityEngine;

public class EnemyController : MonoBehaviour, IController
{
    [SerializeField]
    protected float attackRadius = 2f;

    protected TargetManager targetManager;

    public TargetManager TargetManager { get { return targetManager; } }
    public float AttackRadius { get { return attackRadius; } }

    public virtual void Attack()
    {
        Debug.Log("Enemy attacks");
    }
}