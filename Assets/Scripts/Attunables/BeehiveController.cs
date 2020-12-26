using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attunable))]
public class BeehiveController : MonoBehaviour
{
    private Attunable attunable;

    void Start()
    {
        attunable = GetComponent<Attunable>();
        attunable.onAttuned += Attune;
        Debug.Log("Started");
    }

    private void Attune()
    {
        Debug.Log("You got a bee");
        // Create bee.
        // Cooldown
    }
}
