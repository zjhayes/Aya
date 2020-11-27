using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private float pitch = 1.5f;
    [SerializeField]
    private float yawSpeed = 100f;
    [SerializeField]
    private float zoomSpeed = 4f;
    [SerializeField]
    private float minZoom = 5f;
    [SerializeField]
    private float maxZoom = 15f;

    private float currentYaw = 0f;
    private float currentZoom = 10f;

    void Awake() 
    {
        // Set camera controls.
        InputManager.instance.Controls.Camera.Zoom.performed += ctx => Zoom(ctx.ReadValue<float>());
        InputManager.instance.Controls.Camera.Yaw.performed += ctx => Yaw(ctx.ReadValue<Vector2>());
    }


    void Update()
    {
        ZoomInput();
        YawInput();
    }

    void LateUpdate()
    {
        // Update camera position.
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);
        transform.RotateAround(target.position, Vector3.up, currentYaw);
    }

    private void Zoom(float amount)
    {
        Debug.Log("ZOOM " + amount);
        //currentZoom -= amount * zoomSpeed;
        //currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
    }

    private void Yaw(Vector2 amount)
    {
        Debug.Log("YAW " + amount);
    }

    private void ZoomInput()
    {
        //currentZoom -= input.GetAxis(InputAction.CAMERA_VERTICAL) * zoomSpeed;
        //currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
    }

    private void YawInput()
    {
        //currentYaw -= input.GetAxis(InputAction.CAMERA_HORIZONTAL) * yawSpeed * Time.deltaTime;
    }
}   