using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
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

    private TransformUtility objectScaler;
    private RendererUtility fader;
    private GradualAction scale;
    private GradualAction fade;

    public delegate void OnFieldDestroyed();
    public OnFieldDestroyed onFieldDestroyed;

    public float EndSize
    {
        get { return endSize; }
        set { this.endSize = value; }
    }

    void Start()
    {
        objectScaler = new TransformUtility(transform);
        fader = new RendererUtility();
        fader.AddMesh(GetComponent<Renderer>());

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
        scale = new GradualAction(objectScaler.UpdateLocalScale, startSize, endSize, scaleRate);
        ActionManager.Instance.Add(scale);
    }

    private void Fade()
    {
        // Update alpha of object gradually based on fade rate.
        fade = new GradualAction(fader.UpdateAlpha, startAlpha, endAlpha, fadeRate);
        ActionManager.Instance.Add(fade);
    }

    private void InvokeFieldDestroyedListener()
    {
        if (onFieldDestroyed != null)
        {
            onFieldDestroyed.Invoke();
        }
    }
}
