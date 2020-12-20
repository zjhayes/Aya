using UnityEngine;

public class AttuneTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other) 
    {
        // Attune with attuneable objects.
        if(other.GetComponent<Attunable>() != null)
        {
            other.GetComponent<Attunable>().Attune();
        }
    }
}
