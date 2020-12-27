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
    private float chargeAmount = 0.5f;
    [SerializeField]
    private float maxCharge = 2.0f;

    private float animationChangeRate = 0.25f;

    private Animator animator;
    private bool isCharging = false;
    private float charge = 0.0f;

    void Start()
    {
        this.animator = GetComponent<Animator>();
        InputManager.instance.Controls.Interact.Attune.started += ctx => Charge();
        InputManager.instance.Controls.Interact.Attune.canceled += ctx => Attune();
    }

    void Update()
    {
        if(isCharging && charge <= maxCharge)
        {
            charge += chargeAmount * Time.deltaTime;
        }
    }

    private void Attune()
    {
        // Create attunement field at player's position, factoring offset, no rotation.
        Vector3 position = new Vector3(transform.position.x + fieldOffset.x, transform.position.y + fieldOffset.y, transform.position.z + fieldOffset.z);
        GameObject field = (GameObject) Instantiate(attunementFieldPrefab, position, Quaternion.identity);
        field.GetComponent<FieldController>().EndSize += charge; // Update field size.
        //animator.SetTrigger("Attune"); // Trigger attune animation.
        ResetCharge();
    }

    private void Charge()
    {
        if(isCharging == false)
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
