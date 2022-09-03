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
    private float maxCharge = 4.0f;
    [SerializeField]
    private float animationChangeRate = 0.25f;

    private Animator animator;
    private float charge = 0.0f;
    private bool cooldownReady = true;

    void Start()
    {
        this.animator = GetComponent<Animator>();
        InputManager.Instance.Controls.Interact.Attune.performed += ctx => Attune();
    }

    void Update()
    {
        if(cooldownReady && charge <= maxCharge)
        {
            charge += chargeAmount * Time.deltaTime;
        }
    }

    private void Attune()
    {
        if(cooldownReady)
        {
            // Create attunement field at player's position, factoring offset, no rotation.
            Vector3 position = new Vector3(transform.position.x + fieldOffset.x, transform.position.y + fieldOffset.y, transform.position.z + fieldOffset.z);
            GameObject field = (GameObject) Instantiate(attunementFieldPrefab, position, Quaternion.identity);
            field.GetComponent<FieldController>().EndSize += charge; // Update field size.
            field.GetComponent<FieldController>().onFieldDestroyed += CooldownReady;
            cooldownReady = false; // Cooldown lasts until current field is destroyed.
            charge = 0.0f;
            animator.SetBool("IsCharging", true);
            animator.SetBool("IsCharging", false);
        }
    }

    private void CooldownReady()
    {
        cooldownReady = true;
    }
}
