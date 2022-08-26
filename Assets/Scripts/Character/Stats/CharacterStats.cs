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
        InvokeOnHealthChanged();
    }
    
    public virtual void TakeDamage(int damage)
    {
        // Apply armor buff, clamp negative numbers.
        damage -= armor.Value;
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;
        InvokeOnHealthChanged();
        
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        InvokeOnHealthChanged();
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

    private void InvokeOnHealthChanged()
    {
        if(onHealthChanged != null)
        {
            onHealthChanged.Invoke();
        }
    }
}
