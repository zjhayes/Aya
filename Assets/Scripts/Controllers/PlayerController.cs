using UnityEngine.EventSystems;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private LayerMask movementMask;
    [SerializeField]
    private Interactable focus;
    private Camera cam;
    PlayerMotor motor;

    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        // Return if mouse hovering over UI.
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if(Input.GetMouseButtonDown(0))
        {
            OnLeftMouseClick();
        }

        if(Input.GetMouseButtonDown(1))
        {
            OnRightMouseClick();
        }
    }

    void OnLeftMouseClick()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
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
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
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
