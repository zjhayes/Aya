using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    private float radius = 3f;
    [SerializeField]
    private Transform interactionTranform;

    private bool isFocus = false;
    private Transform player;
    private bool hasInteracted = false;

    public virtual void Interact()
    {
        // This method is meant to be overwritten.
        Debug.Log("Interacting with " + interactionTranform.name);
    }

    void Update()
    {
        if(isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, interactionTranform.position);
            if(distance <= radius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    // Draw yellow sphere around interaction point.
    void OnDrawGizmosSelected()
    {
        if(interactionTranform == null)
        {
            interactionTranform = transform;
        }

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTranform.position, radius);
    }

    public float Radius { 
        get { return radius; } 
    }

    public Transform InteractionTransform 
    {
        get { return interactionTranform; }
    }
}
