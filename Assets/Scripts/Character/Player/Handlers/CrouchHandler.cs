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
        capsule.UpdateCenter(capsule.OriginalCenter * HALF);
        capsule.UpdateHeight(capsule.OriginalHeight * HALF);
        //MovePlayer();
        animation.Crouch(true);
    }

    private void MovePlayer()
    {
        Vector3 up = new Vector3(0, 0.5f, 0);
        PlayerManager.Instance.Player.transform.position += up;
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
