﻿using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    [SerializeField]
    private Stat damage;
    [SerializeField]
    private Stat armor;

    public delegate void OnDeath();
    public OnDeath onDeath;

    public int Health
    {
        get { return currentHealth; }
        set { currentHealth = value; }
    }
    
    public Stat Damage
    {
        get { return damage; }
    }

    public Stat Armor
    {
        get { return armor; }
    }

    void Awake()
    {
        currentHealth = maxHealth;
    }
    
    public virtual void TakeDamage(int damage)
    {
        // Apply armor buff, clamp negative numbers.
        damage -= armor.Value;
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");
        
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        // This method is meant to be overwritten.
        Debug.Log(transform.name + " died.");

        if(onDeath != null)
        {
            onDeath.Invoke();
        }
    }
}