using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other) 
    {
        // Interact with valid object.
        if(other.GetComponent<BeeInteraction>() != null)
        {
            // Pass self to interaction.
            other.GetComponent<BeeInteraction>().Interact(gameObject);
        }
    }
}
