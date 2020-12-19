using UnityEngine;

public class RendererUtility : MonoBehaviour
{
    private Renderer renderer;
    
    public RendererUtility(Renderer renderer)
    {
        this.renderer = renderer;
    }

    public void UpdateAlpha(float newAlpha)
    {
        Color objectColor = renderer.material.color;
        objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, newAlpha);
        renderer.material.color = objectColor;
    }
}
