using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class CapsuleController : MonoBehaviour
{
    CapsuleCollider capsule;
    float originalHeight;
    Vector3 originalCenter;

    public float OriginalHeight { get; }
    public Vector3 OriginalCenter { get; }
    public float Radius { get { return capsule.radius; } }
    public float Height { get { return capsule.height; } }

    void Start()
    {
        capsule = GetComponent<CapsuleCollider>();
        originalHeight = capsule.height;
        originalCenter = capsule.center;
    }

    public void UpdateHeight(float height)
    {
        capsule.height = height;
    }

    public void UpdateCenter(Vector3 center)
    {
        capsule.center = center;
    }

    public void Reset()
    {
        capsule.height = originalHeight;
        capsule.center = originalCenter;
    }
}
