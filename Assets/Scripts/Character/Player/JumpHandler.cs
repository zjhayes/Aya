using UnityEngine;

public class JumpHandler
{
    PlayerController controller;
    PlayerAnimationController animation;
    RigidbodyManager rigidbody;


    public JumpHandler()
    {
        controller = PlayerManager.Instance.Player.GetComponent<PlayerController>();
        animation = PlayerManager.Instance.Player.GetComponent<PlayerAnimationController>();
        rigidbody = PlayerManager.Instance.Player.GetComponent<RigidbodyManager>();

        controller.onJumpChanged += Jump;
    }

    public void Jump()
    {
        if (controller.IsJumping && controller.IsGrounded && animation.IsGrounded())
        {
            rigidbody.Velocity = new Vector3(rigidbody.Velocity.x, controller.JumpPower, rigidbody.Velocity.z);
            controller.IsGrounded = false;
            animation.Animator.applyRootMotion = false;
            controller.GroundCheckDistance = 0.1f;
        }
    }
}
