using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class Enemy : Interactable
{
    PlayerManager playerManager;
    CharacterStats enemyStats;

    void Start() 
    {
        playerManager = PlayerManager.Instance;
        enemyStats = GetComponent<CharacterStats>();
    }

    public override void Interact()
    {
        base.Interact();
        CharacterCombat playerCombat =  playerManager.Player.GetComponent<CharacterCombat>();
        if(playerCombat != null)
        {
            playerCombat.Attack(enemyStats);
        }
    }
}
