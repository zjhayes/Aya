using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    [SerializeField]
    private float attackSpeed = 1f;
    [SerializeField]
    private float attackDelay = .6f;
    private float attackCooldown = 0f;

    public event System.Action OnAttack;

    private CharacterStats myStats;

    void Start() 
    {
        myStats = GetComponent<CharacterStats>();
    }

    void Update() 
    {
        attackCooldown -= Time.deltaTime;
    }

    public void Attack(CharacterStats targetStats)
    {
        if(attackCooldown <= 0f)
        {
            StartCoroutine(DoDamage(targetStats, attackDelay));

            if(OnAttack != null)
            {
                OnAttack();
            }

            attackCooldown = 1f / attackSpeed;
        }
    }

    IEnumerator DoDamage(CharacterStats stats, float delay)
    {
        yield return new WaitForSeconds(delay);

        stats.TakeDamage(myStats.Damage.Value);
    }
}
