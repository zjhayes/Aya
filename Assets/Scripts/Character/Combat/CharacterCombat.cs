using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    [SerializeField]
    private TargetManager targetManager;
    [SerializeField]
    private float attackRadius = 2f; // Enemy will only attack when player is within this radius.
    [SerializeField]
    private float idleDelay = 3f; // Time before returning to idle state.
    [SerializeField]
    private float damageCooldown = 1f; // Delay dealing additional damage after damage delt.
    [SerializeField]
    private List<CollisionPoint> damagePoints;

    private CharacterStats stats;

    public TargetManager TargetManager { get { return targetManager; } }
    public float AttackRadius { get { return attackRadius; } }
    public float IdleDelay { get { return idleDelay; } }

    void Start()
    {
        stats = GetComponent<CharacterStats>();
        DamagePointSetup();
    }

    protected void OnDamagePointEnter(GameObject other)
    {
        if (targetManager.IsTaggedAsTarget(other) && other.GetComponent<CharacterStats>())
        {
            CharacterStats targetStats = other.GetComponent<CharacterStats>();

            DamageTarget(targetStats);
            EnableDamage(false); // Prevent continuous damage on this attack.
        }
    }

    protected void DamageTarget(CharacterStats targetStats)
    {
        if (targetStats != null)
        {
            targetStats.TakeDamage(stats.Damage.Value);
        }
    }

    public virtual void EnableDamage(bool enable)
    {
        // Enable colliders to cause damage.
        foreach (CollisionPoint damagePoint in damagePoints)
        {
            damagePoint.Active = enable;
        }
    }

    protected void DamagePointSetup()
    {
        // Set listeners for enemy damage points.
        foreach (CollisionPoint damagePoint in damagePoints)
        {
            damagePoint.onCollisionPointEnter += OnDamagePointEnter;
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Show enemy's visual radius in editor.
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}