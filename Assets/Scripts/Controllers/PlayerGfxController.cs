using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGfxController : MonoBehaviour
{
    [SerializeField]
    private Material[] materials;
    [SerializeField]
    private GameObject[] graphics;
    private int materialIndex = 0;

    void Start()
    {
        PlayerManager.instance.onHealthChanged += OnHealthChanged;
        materialIndex = graphics.Length;
    }

    private void OnHealthChanged(int newHealth)
    {
        // Cancel if there is no material for current health index.
        if(newHealth > materials.Length || newHealth < 0)
        {
            Debug.LogError("The new health index " + newHealth + " is out of range. A material may not be configured. Leaving index as " + materialIndex);
            return;
        }

        materialIndex = newHealth;
        UpdateGraphics();
    }

    private void UpdateGraphics()
    {
        // Update color of Aya leaves.
        foreach(GameObject graphic in graphics)
        {
            graphic.GetComponent<Renderer>().material = materials[materialIndex];
        }
    }
}
