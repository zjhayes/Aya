using UnityEngine;

[RequireComponent(typeof(TargetManager))]
public class Follow : MonoBehaviour
{
    [SerializeField]
    private bool faceTarget = true;
    [SerializeField]
    private float lookSpeed = 5f;

    private Awareness awareness; // Optional
    private TargetManager targetManager;
    private FaceTarget facing;

    void Start()
    {
        awareness = GetComponent<Awareness>();
        targetManager = GetComponent<TargetManager>();

        //facing =  new FaceTarget(transform);
    }

    void Update()
    {
        if(awareness.IsAlert && faceTarget)
        {
            //facing.Target = targetManager.Target;
            //facing.Look();
        }
    }
}