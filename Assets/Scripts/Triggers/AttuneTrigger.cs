using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttuneTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other) 
    {
        Debug.Log("Attuned with " + other.transform.name);
    }
}
