using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class PlayerController : CharacterController
{
	[SerializeField] float movingTurnSpeed = 360;
	[SerializeField] float stationaryTurnSpeed = 180;
	[SerializeField] float jumpPower = 8f;
	[Range(1f, 4f)][SerializeField] float gravityMultiplier = 2f;
	[SerializeField] float groundCheckDistance = 0.5f;
	[SerializeField] float inAirSpeed = 10.0f;

	private Rigidbody rigidBody;
	private Animator animator;
	private float forwardAmount;
	private float turnAmount;
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

	public float JumpPower 
	{ 
		get { return jumpPower; }
		set { jumpPower = value; }
	}

	public float GravityMultiplier 
	{ 
		get { return gravityMultiplier; } 
		set { gravityMultiplier = value; } 
	}
	public float GroundCheckDistance 
	{ 
		get { return groundCheckDistance; } 
		set { groundCheckDistance = value; } 
	}
	public float InAirSpeed 
	{
		get { return inAirSpeed; }
		set { inAirSpeed = value; }
	}
	public float ForwardAmount 
	{ 
		get { return forwardAmount; }
		set { forwardAmount = value; } 
	}
	public float TurnAmount 
	{ 
		get { return turnAmount; }
		set { turnAmount = value; }
	}
	public Vector3 GroundNormal 
	{ 
		get { return groundNormal; }
		set { groundNormal = value; }
	}

	public bool IsGrounded { get; set; }
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
		// check ground status
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

	}
	
	void ApplyExtraTurnRotation()
	{
		// help the character turn faster (this is in addition to root rotation in the animation)
		float turnSpeed = Mathf.Lerp(stationaryTurnSpeed, movingTurnSpeed, forwardAmount);
		transform.Rotate(0, turnAmount * turnSpeed * Time.deltaTime, 0);
	}
}

