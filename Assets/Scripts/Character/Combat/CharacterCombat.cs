using System;
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

    public event Action OnAttack;

    private CharacterStats stats;
    private CharacterStats targetStats;
    private DelayedAction previousAttack;
    private Cooldown cooldown;

    void Start() 
    {
        stats = GetComponent<CharacterStats>();

        float attackCooldown = 1f / attackSpeed;
        cooldown = new Cooldown(attackCooldown);
    }

    public void Attack(CharacterStats targetStats)
    {
        this.targetStats = targetStats;

        if(cooldown.IsReady)
        {
            DelayedAction delayedAttack = new DelayedAction(DoDamage, attackDelay);
            ActionManager.Instance.Add(delayedAttack);

            if(OnAttack != null)
            {
                OnAttack();
            }

            cooldown.Begin(); // Start cooldown.
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