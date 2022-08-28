using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IController
{
    [SerializeField]
    protected float attackRadius = 2f;
    [SerializeField]
    protected List<CollisionPoint> damagePoints;

    protected TargetManager targetManager;
    protected Animator animator;

    public float AttackRadius { get { return attackRadius; } }
    public TargetManager TargetManager { get { return targetManager; } }
    public Animator Animator { get { return animator; } }

    public virtual void Attack()
    {
        Debug.Log("Enemy attacks");
    }


    public void EnableDamage(bool enable)
    {
        foreach (CollisionPoint damagePoint in damagePoints)
        {
            damagePoint.enabled = enable;
        }
    }
}