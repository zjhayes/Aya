using UnityEngine;

public class JumpHandler
{
    PlayerController controller;
    PlayerAnimationController animation;


    public JumpHandler()
    {
        controller = PlayerManager.Instance.Player.GetComponent<PlayerController>();
        animation = PlayerManager.Instance.Player.GetComponent<PlayerAnimationController>();

        controller.onJumpChanged += Jump;
    }

    public void Jump()
    {
        if (controller.IsJumping && controller.IsGrounded && animation.Animator.GetCurrentAnimatorStateInfo(0).IsName("Grounded"))
        {
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, jumpPower, rigidBody.velocity.z);
            controller.IsGrounded = false;
            animation.Animator.applyRootMotion = false;
            controller.GroundCheckDistance = 0.1f;
        }
    }
}
