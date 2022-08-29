using UnityEngine;

public class TransformUtility
{
    public static void UpdateLocalScale(Transform transform, float newScale)
    {
        transform.localScale = new Vector3(newScale, newScale, newScale);
    }
}
