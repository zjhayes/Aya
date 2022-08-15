using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAbilities : MonoBehaviour
{
    [SerializeField]
    private GameObject attunementFieldPrefab;
    [SerializeField]
    private Vector3 fieldOffset;
    [SerializeField]
    private float chargeAmount = 1.0f;
    [SerializeField]
    private float maxCharge = 2.0f;
    [SerializeField]
    private float attunementDelay = 0.5f;
    [SerializeField]
    private float animationChangeRate = 0.25f;

    private Animator animator;
    private bool isCharging = false;
    private float charge = 0.0f;
    private Cooldown attunementCooldown;

    void Start()
    {
        this.animator = GetComponent<Animator>();
        InputManager.Instance.Controls.Interact.Attune.started += ctx => Charge();
        InputManager.Instance.Controls.Interact.Attune.canceled += ctx => Attune();

        attunementCooldown = new Cooldown(attunementDelay);
    }

    void Update()
    {
        if(isCharging)
        {
            if(charge <= maxCharge)
            {
                charge += chargeAmount * Time.deltaTime;
            }
            else
            {
                Attune(); // Force attune when reached max charge.
            }
        }
    }

    private void Attune()
    {
        if(isCharging)
        {
            // Create attunement field at player's position, factoring offset, no rotation.
            Vector3 position = new Vector3(transform.position.x + fieldOffset.x, transform.position.y + fieldOffset.y, transform.position.z + fieldOffset.z);
            GameObject field = (GameObject) Instantiate(attunementFieldPrefab, position, Quaternion.identity);
            field.GetComponent<FieldController>().EndSize += charge; // Update field size.
            ResetCharge();
            attunementCooldown.Begin(); // Start cooldown.
        }
    }

    private void Charge()
    {
        if(isCharging == false && attunementCooldown.IsReady)
        {
            isCharging = true;
            //Enable charging animation.
            animator.SetBool("IsCharging", true);
        }
    }

    private void ResetCharge()
    {
        isCharging = false;
        charge = 0.0f;
        // Disable charge animation.
        animator.SetBool("IsCharging", false);
    }
}
