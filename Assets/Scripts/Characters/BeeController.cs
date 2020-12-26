using UnityEngine;

public class BeeController : MonoBehaviour
{
    private FaceTarget facing;

    private float lookSpeed = 5f;
    private Transform target;

    void Start()
    {
        this.target = PlayerManager.instance.Player.transform;
        this.facing =  new FaceTarget(transform);
        facing.Target = PlayerManager.instance.Player.transform;
    }

    void Update()
    {
        facing.Look();
    }
}
