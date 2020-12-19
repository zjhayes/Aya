using UnityEngine;

public class TransformUtility
{
    private Transform transform;

    public TransformUtility(Transform transform)
    {
        this.transform = transform;
    }
    public void UpdateLocalScale(float newScale)
    {
        transform.localScale = new Vector3(newScale, newScale, newScale);
    }
}
