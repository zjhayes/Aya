﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
/*    void Start()
    {
        EquipmentManager.Instance.onEquipmentChanged += OnEquipmentChanged;
    }*/

    public override void Die() 
    {
        base.Die();
        PlayerManager.Instance.KillPlayer();
    }
/*
    void OnEquipmentChanged(Equipment newItem, Equipment oldItem) //** TODO: Investigate need for Equipment Manager.
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
    }*/
}
