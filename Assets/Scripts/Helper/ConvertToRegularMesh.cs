using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvertToRegularMesh : MonoBehaviour
{
    // Convert skinned mesh renderer to regular mesh renderer, use for rendering equipment in environments.
    // Add Convert To Regular Mesh component to object with Skinned Mesh Renderer.
    // From the component's context menu, choose 'Convert to Regular Mesh'.

    [ContextMenu("Convert to Regular Mesh")]
    void Convert()
    {
        SkinnedMeshRenderer skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();

        meshFilter.sharedMesh = skinnedMeshRenderer.sharedMesh;
        meshRenderer.sharedMaterials = skinnedMeshRenderer.sharedMaterials;

        DestroyImmediate(skinnedMeshRenderer);
        DestroyImmediate(this);
    }
}
