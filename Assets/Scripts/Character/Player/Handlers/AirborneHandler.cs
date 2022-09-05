using UnityEngine;

public class AirborneHandler
{
	PlayerController controller;
	RigidbodyManager rigidbody;
	PlayerAnimationController animation;
	Transform transform;

	float originalGroundCheckDistance;

	public AirborneHandler()
    {
		controller = PlayerManager.Instance.Player.GetComponent<PlayerController>();
		rigidbody = PlayerManager.Instance.Player.GetComponent<RigidbodyManager>();
		animation = PlayerManager.Instance.Player.GetComponent<PlayerAnimationController>();
		transform = PlayerManager.Instance.Player.transform;
		originalGroundCheckDistance = controller.GroundCheckDistance;
	}

	public void HandleAirborneMovement()
	{
		// Apply extra gravity from multiplier.
		Vector3 extraGravityForce = (Physics.gravity * controller.GravityMultiplier) - Physics.gravity;
		rigidbody.AddForce(extraGravityForce);

		controller.GroundCheckDistance = rigidbody.Velocity.y < 0 ? originalGroundCheckDistance : 0.01f;
	}

	public void CheckGroundStatus()
	{
		RaycastHit hitInfo;
#if UNITY_EDITOR
			// helper to visualise the ground check ray in the scene view
			Debug.DrawLine(transform.position + (Vector3.up * 0.1f), transform.position + (Vector3.up * 0.1f) + (Vector3.down * controller.GroundCheckDistance));
#endif
		// 0.1f is a small offset to start the ray from inside the character
		// it is also good to note that the transform position in the sample assets is at the base of the character
		if (Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, out hitInfo, controller.GroundCheckDistance))
		{
			controller.GroundNormal = hitInfo.normal;
			animation.ApplyRootMotion = true;
			controller.IsGrounded = true;
			controller.IsJumping = false;
			animation.OnGround(true);
		}
		else
		{
			controller.GroundNormal = Vector3.up;
			animation.ApplyRootMotion = false;
			controller.IsGrounded = false;
			animation.OnGround(false);
		}
	}

	// TODO: This is not used. Determine if it is needed. May require root motion enabled/disabled.
	private void InAirMovement()
	{
		if (!controller.IsGrounded)
		{
			transform.Translate(Vector3.forward * controller.ForwardAmount * controller.InAirSpeed * Time.deltaTime);
		}
	}

}
