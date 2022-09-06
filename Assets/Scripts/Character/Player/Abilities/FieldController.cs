using System.Collections.Generic;
using UnityEngine;

public class FieldController : MonoBehaviour
{
    [SerializeField]
    private float startSize = 1.0f;
    [SerializeField]
    private float endSize = 10.0f;
    [SerializeField]
    private float scaleRate = 0.5f;
    [SerializeField]
    private float startAlpha = 1.0f;
    [SerializeField]
    private float endAlpha = 0.0f;
    [SerializeField]
    private float fadeRate = 0.5f;
    [SerializeField]
    private List<Renderer> sphereGfx;

    private GradualAction scale;
    private GradualAction fade;

    // Variable names in field shader.
    const string FILL_REFERENCE = "_Fill";
    const string TRANSPARENCY_REFERENCE = "_Transparency";

    public delegate void OnFieldDestroyed();
    public OnFieldDestroyed onFieldDestroyed;

    public float EndSize
    {
        get { return endSize; }
        set { this.endSize = value; }
    }

    void Start()
    {
        Scale();
        Fade();
    }

    void Update()
    {
        // Destroy when all actions are complete.
        if(scale.IsDone() && fade.IsDone())
        {
            InvokeFieldDestroyedListener();
            Destroy(this.gameObject);
        }
    }

    private void Scale()
    {
        // Update size of object gradually based on scale rate.
        scale = new GradualAction(UpdateScale, startSize, endSize, scaleRate);
        ActionManager.Instance.Add(scale);
    }

    private void UpdateScale(float newScale)
    {
        TransformUtility.UpdateLocalScale(transform, newScale);
    }

    private void Fade()
    {
        // Update alpha of object gradually based on fade rate.
        fade = new GradualAction(UpdateAlpha, startAlpha, endAlpha, fadeRate);
        ActionManager.Instance.Add(fade);
    }

    private void UpdateAlpha(float newAlpha)
    {
        foreach(Renderer gfx in sphereGfx)
        {
            gfx.material.SetFloat(TRANSPARENCY_REFERENCE, newAlpha);
        }
    }

    private void InvokeFieldDestroyedListener()
    {
        if (onFieldDestroyed != null)
        {
            onFieldDestroyed.Invoke();
        }
    }
}
