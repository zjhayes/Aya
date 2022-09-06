using UnityEngine;

public class TransformUtility
{
    public static void UpdateLocalScale(Transform transform, float newScale)
    {
        transform.localScale = new Vector3(newScale, newScale, newScale);
    }

    public static void UpdatePosition(Transform transform, Vector3 newPosition)
    {
        transform.position = newPosition;
    }

    public static void UpdateRotation(Transform transform, Quaternion newRotation)
    {
        transform.rotation = newRotation;
    }
}
