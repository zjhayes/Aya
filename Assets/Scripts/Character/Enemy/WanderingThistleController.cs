using UnityEngine;

[RequireComponent(typeof(CharacterCombat))]
[RequireComponent(typeof(CharacterStats))]
public class WanderingThistleController : MonoBehaviour
{
    [SerializeField]
    private GameObject head;

    CharacterCombat combat;
    CharacterStats stats;
    Animator animator;
    Awareness awareness;
    TargetManager target;
    FaceTarget faceTarget;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
