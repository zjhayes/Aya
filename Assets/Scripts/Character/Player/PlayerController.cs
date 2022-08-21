using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour, IController
{
	[SerializeField] float m_MovingTurnSpeed = 360;
	[SerializeField] float m_StationaryTurnSpeed = 180;
	[SerializeField] float jumpPower = 8f;
	[Range(1f, 4f)][SerializeField] float m_GravityMultiplier = 2f;
	[SerializeField] float m_RunCycleLegOffset = 0.2f; //specific to the character in sample assets, will need to be modified to work with others
	[SerializeField] float m_MoveSpeedMultiplier = 1f;
	[SerializeField] float m_AnimSpeedMultiplier = 1f;
	[SerializeField] float groundCheckDistance = 0.5f;
	[SerializeField] float inAirSpeed = 10.0f;

	private Rigidbody rigidBody;
	private Animator animator;
	private float origGroundCheckDistance;
	private float turnAmount;
	private float forwardAmount;
	private Vector3 groundNormal;
	private const float HALF = 0.5f;

	private bool isGrounded;
	private bool isMoving;
	private bool isRunning;
	private bool isCrouching;
	private bool isJumping;

	public delegate void OnMovementChanged(bool isAlert);
	public OnMovementChanged onMovementChanged;

	public delegate void OnCrouchChanged();
	public OnCrouchChanged onCrouchChanged;

	public delegate void OnJumpChanged();
	public OnJumpChanged onJumpChanged;

	public float GroundCheckDistance { get; set; }

	public bool IsGrounded { get; }
	public bool IsMoving { get; }
	public bool IsRunning { get; set; }
	public bool IsCrouching 
	{
		get { return isCrouching; }
        set 
		{ 
			isCrouching = value;
			onCrouchChanged?.Invoke();
		}
	}
	public bool IsJumping
	{
		get { return isJumping; }
		set
		{
			isJumping = value;
			onJumpChanged?.Invoke();
		}
	}

	void Start()
	{
		animator = GetComponent<Animator>();
		rigidBody = GetComponent<Rigidbody>();

		rigidBody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
		origGroundCheckDistance = groundCheckDistance;

		isMoving = false;
		isRunning = false;
		isCrouching = false;
		isJumping = false;
	}

	public void Move(Vector3 move)
	{
		// convert the world relative moveInput vector into a local-relative
		// turn amount and forward amount required to head in the desired
		// direction.
		if (move.magnitude > 1f) move.Normalize();
		move = transform.InverseTransformDirection(move);
		CheckGroundStatus();
		move = Vector3.ProjectOnPlane(move, groundNormal);
		turnAmount = Mathf.Atan2(move.x, move.z);
		forwardAmount = move.z;

		if (isMoving && forwardAmount == 0) // Stopped.
		{
			isMoving = false;
			onMovementChanged.Invoke(false);
		}
		else if (!isMoving && forwardAmount > 0) // Started moving.
		{
			isMoving = true;
			onMovementChanged.Invoke(true);
		}

		ApplyExtraTurnRotation();

		// control and velocity handling is different when grounded and airborne:
		if (isGrounded)
		{
			HandleGroundedMovement();
		}
		else
		{
			HandleAirborneMovement();
		}

		// send input and other state parameters to the animator
		UpdateAnimator(move);
	}


	void UpdateAnimator(Vector3 move)
	{
		// update the animator parameters
		animator.SetFloat("Forward", forwardAmount, 0.1f, Time.deltaTime);
		animator.SetFloat("Turn", turnAmount, 0.1f, Time.deltaTime);
		animator.SetBool("OnGround", isGrounded);
		if (!isGrounded)
		{
			animator.SetFloat("Jump", rigidBody.velocity.y);
		}

		// calculate which leg is behind, so as to leave that leg trailing in the jump animation
		// (This code is reliant on the specific run cycle offset in our animations,
		// and assumes one leg passes the other at the normalized clip times of 0.0 and 0.5)
		float runCycle =
			Mathf.Repeat(
				animator.GetCurrentAnimatorStateInfo(0).normalizedTime + m_RunCycleLegOffset, 1);
		float jumpLeg = (runCycle < HALF ? 1 : -1) * forwardAmount;
		if (isGrounded)
		{
			animator.SetFloat("JumpLeg", jumpLeg);
		}

		// the anim speed multiplier allows the overall speed of walking/running to be tweaked in the inspector,
		// which affects the movement speed because of the root motion.
		if (isGrounded && move.magnitude > 0)
		{
			animator.speed = m_AnimSpeedMultiplier;
		}
		else
		{
			// don't use that while airborne
			animator.speed = 1;
		}
	}

	
	void HandleAirborneMovement()
	{
		// apply extra gravity from multiplier:
		Vector3 extraGravityForce = (Physics.gravity * m_GravityMultiplier) - Physics.gravity;
		rigidBody.AddForce(extraGravityForce);

		groundCheckDistance = rigidBody.velocity.y < 0 ? origGroundCheckDistance : 0.01f;
	}

	/*
	void HandleGroundedMovement()
	{
		// check whether conditions are right to allow a jump:
		if (isJumping && !isCrouching && animator.GetCurrentAnimatorStateInfo(0).IsName("Grounded"))
		{
			Debug.Log("Here");
			// jump!
			rigidBody.velocity = new Vector3(rigidBody.velocity.x, jumpPower, rigidBody.velocity.z);
			isGrounded = false;
			animator.applyRootMotion = false;
			groundCheckDistance = 0.1f;
		}
	}*/

	void ApplyExtraTurnRotation()
	{
		// help the character turn faster (this is in addition to root rotation in the animation)
		float turnSpeed = Mathf.Lerp(m_StationaryTurnSpeed, m_MovingTurnSpeed, forwardAmount);
		transform.Rotate(0, turnAmount * turnSpeed * Time.deltaTime, 0);
	}


	public void OnAnimatorMove()
	{
		// we implement this function to override the default root motion.
		// this allows us to modify the positional speed before it's applied.
		if (isGrounded && Time.deltaTime > 0)
		{
			Vector3 v = (animator.deltaPosition * m_MoveSpeedMultiplier) / Time.deltaTime;

			// we preserve the existing y part of the current velocity.
			v.y = rigidBody.velocity.y;
			rigidBody.velocity = v;
		}
	}


	void CheckGroundStatus()
	{
		RaycastHit hitInfo;
#if UNITY_EDITOR
			// helper to visualise the ground check ray in the scene view
			Debug.DrawLine(transform.position + (Vector3.up * 0.1f), transform.position + (Vector3.up * 0.1f) + (Vector3.down * m_GroundCheckDistance));
#endif
		// 0.1f is a small offset to start the ray from inside the character
		// it is also good to note that the transform position in the sample assets is at the base of the character
		if (Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, out hitInfo, groundCheckDistance))
		{
			groundNormal = hitInfo.normal;
			isGrounded = true;
			animator.applyRootMotion = true;
		}
		else
		{
			isGrounded = false;
			groundNormal = Vector3.up;
			animator.applyRootMotion = false;
		}
	}
}

