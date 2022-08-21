using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimationController : MonoBehaviour
{
    Animator animator;

    public const string CROUCH = "Crouch";

    public Animator Animator { get; }

    void Start()
    {
        animator = PlayerManager.Instance.Player.GetComponent<Animator>();
    }

    public void Crouch(bool crouch)
    {
        animator.SetBool(CROUCH, value);
    }

}
