using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
    }

    public override void Die() 
    {
        base.Die();
        PlayerManager.instance.KillPlayer();
    }

    void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        if(newItem != null)
        {
            Armor.AddModifier(newItem.ArmorModifier);
            Damage.AddModifier(newItem.DamageModifier);
        }
        
        if(oldItem != null)
        {
            Armor.RemoveModifier(oldItem.ArmorModifier);
            Damage.RemoveModifier(oldItem.DamageModifier);
        }
    }
}
