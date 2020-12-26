using UnityEngine;

[RequireComponent(typeof(Awareness))]
public class Follow : MonoBehaviour
{
    [SerializeField]
    private bool faceTarget = true;
    [SerializeField]
    private float lookSpeed = 5f;

    private Awareness awareness;
    private FaceTarget facing;

    void Start()
    {
        awareness = GetComponent<Awareness>();
        facing =  new FaceTarget(transform);
    }

    void Update()
    {
        if(awareness.IsAlert && faceTarget)
        {
            facing.Target = awareness.Target;
            facing.Look();
        }
    }
}