using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other) 
    {
        // Interact with valid object.
        if(other.GetComponent<BeeInteractable>() != null)
        {
            // Pass self to interaction.
            other.GetComponent<BeeInteractable>().Interact(gameObject);
        }
    }
}
