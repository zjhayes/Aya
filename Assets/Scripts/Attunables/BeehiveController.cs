using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attunable))]
public class BeehiveController : MonoBehaviour
{
    [SerializeField]
    private GameObject beePrefab;
    [SerializeField]
    private Vector3 spawnOffset;

    private Attunable attunable;

    void Start()
    {
        attunable = GetComponent<Attunable>();
        attunable.onAttuned += Attune;
        Debug.Log("Started");
    }

    private void Attune()
    {
        Vector3 position = new Vector3(transform.position.x + spawnOffset.x, transform.position.y + spawnOffset.y, transform.position.z + spawnOffset.z);
        Instantiate(beePrefab, position, Quaternion.identity);
        // Cooldown
    }
}
