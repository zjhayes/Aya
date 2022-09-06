using System.Collections.Generic;
using UnityEngine;

public class RendererUtility
{
    private List<Renderer> renderers;

    public RendererUtility()
    {
        renderers = new List<Renderer>();
    }

    public void AddMesh(Renderer renderer)
    {
        renderers.Add(renderer);
    }

    public void UpdateAlpha(float newAlpha)
    {
        foreach(Renderer renderer in renderers)
        {
            UpdateAlpha(newAlpha, renderer);
        }
    }

    private void UpdateAlpha(float newAlpha, Renderer renderer)
    {
        Debug.Log(newAlpha);
        Color objectColor = new Color(0.0f, 0.0f, 0.0f, newAlpha); // Default to no color.

        if(renderer.material.HasProperty("_Color"))
        {
            // Preserve color, if it exists.
            objectColor = renderer.material.color;
            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, newAlpha);
        }

        // Apply new aplha.
        renderer.material.color = objectColor;
    }
}
