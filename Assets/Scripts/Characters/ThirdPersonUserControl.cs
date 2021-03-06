using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class ThirdPersonUserControl : MonoBehaviour
    {
        private ThirdPersonCharacter m_Character; // A reference to the ThirdPersonCharacter on the object
        private Transform m_Cam;                  // A reference to the main camera in the scenes transform
        private Vector3 m_CamForward;             // The current forward direction of the camera
        private Vector3 m_Move;
        private float m_Verticle = 0.0f;
        private float m_Horizontal = 0.0f;
        private bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.
        private bool m_Crouch;
        private bool m_Run;

        
        private void Start()
        {
            // get the transform of the main camera
            if (Camera.main != null)
            {
                m_Cam = Camera.main.transform;
            }
            else
            {
                Debug.LogWarning(
                    "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
                // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
            }

            // get the third person character ( this should never be null due to require component )
            m_Character = GetComponent<ThirdPersonCharacter>();

            // Set player controls. 
            InputManager.instance.Controls.Movement.Move.performed += ctx => Move(ctx.ReadValue<Vector2>());
            InputManager.instance.Controls.Movement.Jump.performed += ctx => Jump();
            InputManager.instance.Controls.Movement.Crouch.started += ctx => Crouch(true);
            InputManager.instance.Controls.Movement.Crouch.canceled += ctx => Crouch(false);
            InputManager.instance.Controls.Movement.Run.performed += ctx => ToggleRun();
        }

        void Move(Vector2 direction)
        {
            m_Verticle = direction.y;
            m_Horizontal = direction.x;
        }

        public void Jump()
        {
            if(!m_Jump)
            {
                m_Jump = true;
            }
        }

        private void Crouch(bool crouch) 
        {
            m_Crouch = crouch;
        }

        private void ToggleRun()
        {
            m_Run = !m_Run;
        }

        // Fixed update is called in sync with physics.
        private void FixedUpdate()
        {            
            // calculate move direction to pass to character
            if (m_Cam != null)
            {
                // calculate camera relative direction to move:
                m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
                m_Move = m_Verticle * m_CamForward + m_Horizontal * m_Cam.right;
            }
            else
            {
                // we use world-relative directions in the case of no main camera
                m_Move = m_Verticle * Vector3.forward + m_Horizontal * Vector3.right;
            }

			// walk speed multiplier
	        if (m_Run) m_Move *= 2f;

            // pass all parameters to the character control script
            m_Character.Move(m_Move, m_Crouch, m_Jump);
            m_Jump = false;
        }
    }
}
