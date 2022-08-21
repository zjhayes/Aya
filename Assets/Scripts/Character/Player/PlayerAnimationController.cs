using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] 
    float animationSpeedMultiplier = 1f;
    [SerializeField] 
    float runCycleLegOffset = 0.2f;

    PlayerController controller;
    Animator animator;
    RigidbodyManager rigidbody;

    const string CROUCH = "Crouch";
    const string ON_GROUND = "OnGround";
    const string FORWARD = "Forward";
    const string TURN = "Turn";
    const string JUMP = "Jump";
    const string JUMP_LEG = "JumpLeg";
    const float HALF = 0.5f;

    public Animator Animator 
    { 
        get { return animator; }
        private set { animator = value; }
    }

    public bool ApplyRootMotion
    {
        get { return animator.applyRootMotion; }
        set { animator.applyRootMotion = value; }
    }

    void Start()
    {
        controller = PlayerManager.Instance.Player.GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
        rigidbody = PlayerManager.Instance.Player.GetComponent<RigidbodyManager>();

        controller.onCrouchChanged += OnCrouchChanged;
    }

    private void OnCrouchChanged()
    {
        Crouch(controller.IsCrouching);
    }

    private void OnGroundingChanged()
    {
        OnGround(controller.IsGrounded);
    }

    public void Crouch(bool crouch)
    {
        animator.SetBool(CROUCH, crouch);
    }

    public void OnGround(bool grounded)
    {
        animator.SetBool(ON_GROUND, grounded);
    }

    public bool IsGrounded()
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName("Grounded");
    }

    public void UpdateAnimator(Vector3 move)
    {
        // update the animator parameters
        animator.SetFloat(FORWARD, controller.ForwardAmount, 0.1f, Time.deltaTime);
        animator.SetFloat(TURN, controller.TurnAmount, 0.1f, Time.deltaTime);
        if (!controller.IsGrounded)
        {
            animator.SetFloat(JUMP, rigidbody.Velocity.y);
        }
        
        // calculate which leg is behind, so as to leave that leg trailing in the jump animation
        // (This code is reliant on the specific run cycle offset in our animations,
        // and assumes one leg passes the other at the normalized clip times of 0.0 and 0.5)
        float runCycle =
            Mathf.Repeat(
                animator.GetCurrentAnimatorStateInfo(0).normalizedTime + runCycleLegOffset, 1);
        float jumpLeg = (runCycle < HALF ? 1 : -1) * controller.ForwardAmount;
        if (controller.IsGrounded)
        {
            animator.SetFloat(JUMP_LEG, jumpLeg);
        }

        // the anim speed multiplier allows the overall speed of walking/running to be tweaked in the inspector,
        // which affects the movement speed because of the root motion.
        if (controller.IsGrounded && move.magnitude > 0)
        {
            animator.speed = animationSpeedMultiplier;
        }
        else
        {
            // don't use that while airborne
            animator.speed = 1;
        }
    }

    // Overrides MonoBehaviour
    public void OnAnimatorMove()
    {
        float moveSpeedMultiplier = 1f; // Previously serialized.
        // we implement this function to override the default root motion.
        // this allows us to modify the positional speed before it's applied.
        if (controller.IsGrounded && Time.deltaTime > 0)
        {
            Vector3 v = (animator.deltaPosition * moveSpeedMultiplier) / Time.deltaTime;

            // we preserve the existing y part of the current velocity.
            v.y = rigidbody.Velocity.y;
            rigidbody.Velocity = v;
        }
    }
}
