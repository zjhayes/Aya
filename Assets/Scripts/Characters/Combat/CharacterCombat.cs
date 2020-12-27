using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    [SerializeField]
    private float attackSpeed = 0.4f;
    [SerializeField]
    private float attackDelay = 0.6f;
    private float attackCooldown = 0f;

    public event System.Action OnAttack;

    private CharacterStats stats;
    private CharacterStats targetStats;
    private DelayedAction previousAttack;

    void Start() 
    {
        stats = GetComponent<CharacterStats>();
    }

    void Update() 
    {
        attackCooldown -= Time.deltaTime;
    }

    public void Attack(CharacterStats targetStats)
    {
        this.targetStats = targetStats;

        if(attackCooldown <= 0f)
        {
            DelayedAction delayedAttack = new DelayedAction(DoDamage, attackDelay);
            ActionManager.instance.Add(delayedAttack);

            if(OnAttack != null)
            {
                OnAttack();
            }

            attackCooldown = 1f / attackSpeed;
            this.previousAttack = delayedAttack;
        }
    }

    // Cancelling attack prevents target from taking damage
    // if an attack is pending.
    // Cancelling attack does not cancel the animation,
    public void CancelAttack()
    {
        if(previousAttack != null)
        {
            previousAttack.Cancel();
        }
    }

    void DoDamage()
    {
        targetStats.TakeDamage(stats.Damage.Value);
    }
}