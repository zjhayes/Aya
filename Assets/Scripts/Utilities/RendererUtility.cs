using UnityEngine;

public class RendererUtility
{
    private Renderer renderer;
    
    public RendererUtility(Renderer renderer)
    {
        this.renderer = renderer;
    }

    public void UpdateAlpha(float newAlpha)
    {
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
