﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterCombat))]
[RequireComponent(typeof(CharacterStats))]
[RequireComponent(typeof(Awareness))]
[RequireComponent(typeof(Attunable))]
public class CorruptRootController : MonoBehaviour
{
    [SerializeField]
    private float lookSpeed = 5f;
    [SerializeField]
    private float attackRadius = 2f;
    [SerializeField]
    private float idleDelay = 3f; // Time before returning to idle state.
    [SerializeField]
    private float idleSize = 0.5f;
    [SerializeField]
    private float alertSize = 1.0f;
    [SerializeField]
    private float sizeChangeRate = 3f; // Rate mesh changes size on state change.

    private Animator animator;
    private Transform target;
    private UnityEngine.AI.NavMeshAgent agent;
    private CharacterCombat combat;
    private CharacterStats stats;
    private Awareness awareness;
    private Attunable attunable;
    private DelayedAction previousAction;
    private TransformUtility objectScaler;

    void Start()
    {
        animator = GetComponent<Animator>();
        combat = GetComponent<CharacterCombat>();
        stats = GetComponent<CharacterStats>();
        awareness = GetComponent<Awareness>();
        attunable = GetComponent<Attunable>();
        objectScaler = new TransformUtility(transform);

        awareness.onAwarenessChanged += OnAwarenessChanged;
        attunable.onAttuned += Attune;
        stats.onDeath += Die;

        objectScaler.UpdateLocalScale(idleSize);
    }

    void Update()
    {
        if(awareness.IsAlert)
        {
            float distance = Vector3.Distance(awareness.Target.position, transform.position);
            // If target is in attack range...
            if(distance <= attackRadius)
            {
                AttackTarget();
            }
        }
    }

    private void OnAwarenessChanged(bool isAlert)
    {
        if(isAlert)
        {
            Alert();
            if(previousAction != null) { previousAction.Cancel(); } // Stop previous action.
        }
        else
        {
            DelayedAction idleAfterDelay = new DelayedAction(Idle, idleDelay);
            ActionManager.instance.Add(idleAfterDelay);
            previousAction = idleAfterDelay; // Store action, so it can be cancelled later.
        }
    }

    private void Alert()
    {
        animator.SetBool("isAlert", true);
        Grow();
    }

    private void Idle()
    {
        if(!awareness.IsAlert) // Double-check alertness after idle delay.
        {
            animator.SetBool("isAlert", false);
            Shrink();
        }
    }

    private void Shrink()
    {
        GradualAction shrink = new GradualAction(objectScaler.UpdateLocalScale, transform.localScale.y, idleSize, sizeChangeRate);
        ActionManager.instance.Add(shrink);
    }

    private void Grow()
    {
        GradualAction grow = new GradualAction(objectScaler.UpdateLocalScale, transform.localScale.y, alertSize, sizeChangeRate);
        ActionManager.instance.Add(grow);
    }

    private void AttackTarget()
    {
        animator.SetTrigger("triggerAttack");
        CharacterStats targetStats = awareness.Target.GetComponent<CharacterStats>();
        if(targetStats != null)
        {
            combat.Attack(targetStats);
        }
    }
    
    private void Attune()
    {
        // Cause damage on attunement.
        stats.TakeDamage(1);
    }

    private void Die()
    {
        animator.SetTrigger("isDead");
        awareness.IsAlert = false;
        awareness.Enabled = false;
    }

    private void OnDrawGizmosSelected() 
    {
        // Show enemy's visual radius in editor.
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}