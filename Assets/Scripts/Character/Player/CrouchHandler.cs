using UnityEngine;

public class CrouchHandler
{
    PlayerController controller;
    PlayerAnimationController animation;
    CapsuleManager capsule;
    RigidbodyManager rigidbody;
    const float HALF = 0.5f;

    public CrouchHandler()
    {
        controller = PlayerManager.Instance.Player.GetComponent<PlayerController>();
        animation = PlayerManager.Instance.Player.GetComponent<PlayerAnimationController>();
        rigidbody = PlayerManager.Instance.Player.GetComponent<RigidbodyManager>();
        capsule = PlayerManager.Instance.Player.GetComponent<CapsuleManager>();

        controller.onCrouchChanged += UpdateCrouch;
    }
    
    void UpdateCrouch()
    {
        if(controller.IsCrouching)
        {
            Crouch();
        }
        else
        {
            if(StandingHeadroom())
            {
                Stand();
            }
            else
            {
                controller.IsCrouching = true;
            }
        }
    }

    private void Crouch()
    {
        capsule.UpdateHeight(capsule.OriginalHeight * HALF);
        capsule.UpdateCenter(capsule.OriginalCenter * HALF);
        animation.Crouch(true);
    }

    private void Stand()
    {
        capsule.Reset();
        animation.Crouch(false);
    }

    private bool StandingHeadroom()
    {
        Ray crouchRay = new Ray(rigidbody.Position + Vector3.up * capsule.Radius * HALF, Vector3.up);
        float crouchRayLength = capsule.Height - capsule.Radius * HALF;
        if (Physics.SphereCast(crouchRay, capsule.Radius * HALF, crouchRayLength, Physics.AllLayers, QueryTriggerInteraction.Ignore))
        {
            return false;
        }
        return true;
    }
}
