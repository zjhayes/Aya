using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGfxController : MonoBehaviour
{
    [SerializeField]
    private Material[] leafMaterials;
    [SerializeField]
    private GameObject[] leafGraphics;
    private int leafMaterialIndex = 0;

    [SerializeField]
    private GameObject eyeGraphics;
    [SerializeField]
    private int blinkRate = 2;

    void Start()
    {
        PlayerManager.instance.onHealthChanged += OnHealthChanged;
        leafMaterialIndex = leafGraphics.Length;
    }

    void Update()
    {
        // Randomly blink.
        Boolean isBlinking = (UnityEngine.Random.Range(0, blinkRate) == 0);
        UpdateBlink(isBlinking);
    }

    private void OnHealthChanged(int newHealth)
    {
        // Cancel if there is no material for current health index.
        if(newHealth > leafMaterials.Length || newHealth < 0)
        {
            Debug.LogError("The new health index " + newHealth + " is out of range. A material may not be configured. Leaving index as " + leafMaterialIndex);
            return;
        }

        leafMaterialIndex = newHealth;
        UpdateGraphics();
    }

    private void UpdateGraphics()
    {
        // Update color of Aya leaves.
        foreach(GameObject graphic in leafGraphics)
        {
            graphic.GetComponent<Renderer>().material = leafMaterials[leafMaterialIndex];
        }
    }

    private void UpdateBlink(bool isBlinking)
    {
        eyeGraphics.SetActive(!isBlinking);
    }
}
