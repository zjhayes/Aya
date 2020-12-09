using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterCombat))]
public class DamageOnStayTrigger : MonoBehaviour
{
    CharacterCombat combat;

    void Start()
    {
        combat = GetComponent<CharacterCombat>();
    }

    void OnTriggerStay(Collider other) 
    {
        CharacterStats targetStats = other.GetComponent<CharacterStats>();
        if(targetStats != null)
        {
            combat.Attack(targetStats);
        }
    }
}
