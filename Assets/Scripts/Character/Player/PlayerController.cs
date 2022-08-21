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

	private Vector3 movement;
	private float forwardAmount;
	private float turnAmount;
	private Vector3 groundNormal;
	private const float HALF = 0.5f;

	private bool isGrounded;
	private bool isMoving;
	private bool isRunning;
	private bool isCrouching;
	private bool isJumping;

	public delegate void OnMovementChanged();
	public OnMovementChanged onMovementChanged;

	public delegate void OnCrouchChanged();
	public OnCrouchChanged onCrouchChanged;

	public delegate void OnJumpChanged();
	public OnJumpChanged onJumpChanged;

	public float MovingTurnSpeed
    {
		get { return movingTurnSpeed; }
		set { movingTurnSpeed = value; }
    }
	public float StationaryTurnSpeed
    {
		get { return stationaryTurnSpeed; }
		set { stationaryTurnSpeed = value; }
    }
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

	public Vector3 Movement
    {
		get { return movement; }
		set 
		{
			movement = value;
			onMovementChanged.Invoke();
		}
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
	public bool IsMoving { get; set; }
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
		isMoving = false;
		isRunning = false;
		isCrouching = false;
		isJumping = false;
	}
}

