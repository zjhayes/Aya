using System;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerControls : MonoBehaviour
{
    private PlayerController controller; // A reference to the ThirdPersonCharacter on the object
    private Transform camera;                  // A reference to the main camera in the scenes transform
    private Vector3 cameraForward;             // The current forward direction of the camera
    private Vector3 movement;
    private float verticleMovement = 0.0f;
    private float horizontalMovement = 0.0f;                     // the world-relative desired move direction, calculated from the camForward and user input.
    private CrouchHandler crouchHandler;
    private JumpHandler jumpHandler;


    void Start()
    {
        // get the transform of the main camera
        if (Camera.main != null)
        {
            camera = Camera.main.transform;
        }
        else
        {
            Debug.LogWarning(
                "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
            // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
        }

        // get the third person character ( this should never be null due to require component )
        controller = GetComponent<PlayerController>();

        // Set player controls. 
        InputManager.Instance.Controls.Movement.Move.performed += ctx => Move(ctx.ReadValue<Vector2>());
        InputManager.Instance.Controls.Movement.Jump.started += ctx => Jump();
        InputManager.Instance.Controls.Movement.Crouch.started += ctx => ToggleCrouch();
        InputManager.Instance.Controls.Movement.Run.started += ctx => ToggleRun();

        // Set up handlers.
        crouchHandler = new CrouchHandler();
        jumpHandler = new JumpHandler();
    }

    void Move(Vector2 direction)
    {
        verticleMovement = direction.y;
        horizontalMovement = direction.x;
    }

    public void Jump()
    {
        if (!controller.IsJumping)
        {
            controller.IsJumping = true;
        }
    }

    private void Crouch(bool crouch)
    {
        controller.IsCrouching = crouch;
    }

    private void ToggleCrouch()
    {
        Crouch(!controller.IsCrouching);
    }

    private void Run(bool run)
    {
        controller.IsRunning = run;
    }

    private void ToggleRun()
    {
        Run(!controller.IsRunning);
    }

    // Fixed update is called in sync with physics.
    private void FixedUpdate()
    {
        // calculate move direction to pass to character
        if (camera != null)
        {
            // calculate camera relative direction to move:
            cameraForward = Vector3.Scale(camera.forward, new Vector3(1, 0, 1)).normalized;
            movement = verticleMovement * cameraForward + horizontalMovement * camera.right;
        }
        else
        {
            // we use world-relative directions in the case of no main camera
            movement = verticleMovement * Vector3.forward + horizontalMovement * Vector3.right;
        }

        // walk speed multiplier
        if (controller.IsRunning) movement *= 2f;

        // pass all parameters to the character control script
        controller.Move(movement);
        controller.IsJumping = false;
    }
}

