using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    [SerializeField]
    private GameObject attunementFieldPrefab;
    [SerializeField]
    private Vector3 fieldOffset;

    void Start()
    {
        InputManager.instance.Controls.Interact.Attune.performed += ctx => Attune();
    }

    private void Attune()
    {
        // Create attunement field at player's position, factoring offset, no rotation.
        Vector3 position = new Vector3(transform.position.x + fieldOffset.x, transform.position.y + fieldOffset.y, transform.position.z + fieldOffset.z);
        Instantiate(attunementFieldPrefab, position, Quaternion.identity);
    }
}
