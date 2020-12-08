using UnityEngine.EventSystems;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerControllerOld : MonoBehaviour
{
    [SerializeField]
    private LayerMask movementMask;

    private Interactable focus;
    private Camera cam;
    private PlayerMotor motor;

    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    void Awake() 
    {
        // Set player controls.
        InputManager.instance.Controls.Interact.Attune.performed += ctx => Attune();
        InputManager.instance.Controls.Interact.LeftClick.performed += ctx => OnLeftMouseClick();
        InputManager.instance.Controls.Interact.RightClick.performed += ctx => OnRightMouseClick();
    }

    public void Attune()
    {
        Debug.Log("Attuned.");
    }

    void OnLeftMouseClick()
    {
        // Return if mouse hovering over UI.
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        Vector3 mousePosition = InputManager.instance.Controls.Interact.MousePosition.ReadValue<Vector2>();
        Ray ray = cam.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        int maskRange = 100;

        if(Physics.Raycast(ray, out hit, maskRange, movementMask))
        {
            motor.MoveToPoint(hit.point);
            RemoveFocus();
        }
    }

    void OnRightMouseClick()
    {
        // Return if mouse hovering over UI.
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        Vector3 mousePosition = InputManager.instance.Controls.Interact.MousePosition.ReadValue<Vector2>();
        Ray ray = cam.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        int maskRange = 100;

        if(Physics.Raycast(ray, out hit, maskRange))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if(interactable != null)
            {
                SetFocus(interactable);
            }
        }
    }

    void SetFocus(Interactable newFocus)
    {
        if(newFocus != focus)
        {
            if(focus != null)
            {
                focus.OnDefocused();
            }
            focus = newFocus;
            motor.FollowTarget(newFocus);
        }

        newFocus.OnFocused(transform);
    }

    void RemoveFocus()
    {
        if(focus != null)
        {
            focus.OnDefocused();
        }

        focus = null;
        motor.StopFollowingTarget();
    }
}
