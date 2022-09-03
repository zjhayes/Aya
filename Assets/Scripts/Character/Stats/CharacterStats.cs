using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 100;
    [SerializeField]
    private Stat damage;
    [SerializeField]
    private Stat armor;

    private int currentHealth;

    public delegate void OnDeath();
    public OnDeath onDeath;

    public delegate void OnHealthChanged();
    public OnHealthChanged onHealthChanged;

    public int Health
    {
        get { return currentHealth; }
        set 
        { 
            currentHealth = value;
            InvokeOnHealthChanged();
        }
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
        Health = maxHealth;
    }
    
    public virtual void TakeDamage(int damage)
    {
        // Apply armor buff, clamp negative numbers.
        damage -= armor.Value;
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        Health -= damage;
        
        if(Health <= 0)
        {
            Die();
        }
    }

    public virtual void Heal(int amount)
    {
        Health = Mathf.Clamp(Health + amount, 0, maxHealth);
    }

    public virtual void Die()
    {
        if(onDeath != null)
        {
            onDeath.Invoke();
        }
    }

    private void InvokeOnHealthChanged()
    {
        if(onHealthChanged != null)
        {
            onHealthChanged.Invoke();
        }
    }
}
