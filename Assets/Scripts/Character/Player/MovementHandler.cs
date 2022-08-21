using UnityEngine;

public class MovementHandler
{
	PlayerController controller;
	Transform transform;

	public MovementHandler()
    {
		controller = PlayerManager.Instance.Player.GetComponent<PlayerController>();
		controller.onMovementChanged += Move;
	}

	void Move()
	{
		Vector3 move = controller.Movement;
		// convert the world relative moveInput vector into a local-relative
		// turn amount and forward amount required to head in the desired
		// direction.
		if (controller.Movement.magnitude > 1f) move.Normalize();
		move = controller.transform.InverseTransformDirection(controller.Movement);

		move = Vector3.ProjectOnPlane(move, controller.GroundNormal);
		controller.TurnAmount = Mathf.Atan2(move.x, move.z);
		controller.ForwardAmount = move.z;

		if (controller.IsMoving && controller.ForwardAmount == 0) // Stopped.
		{
			controller.IsMoving = false;
		}
		else if (!controller.IsMoving && controller.ForwardAmount > 0) // Started moving.
		{
			controller.IsMoving = true;
		}

		ApplyExtraTurnRotation();

	}

	void ApplyExtraTurnRotation()
	{
		// help the character turn faster (this is in addition to root rotation in the animation)
		float turnSpeed = Mathf.Lerp(controller.StationaryTurnSpeed, controller.MovingTurnSpeed, controller.ForwardAmount);
		controller.transform.Rotate(0, controller.TurnAmount * turnSpeed * Time.deltaTime, 0);
	}

}
