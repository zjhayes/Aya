using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof(CinemachineFreeLook))]
public class CameraController : MonoBehaviour
{
    [SerializeField]
    [Range(0f, 10f)] 
    private float LookSpeed = 1f;
    [SerializeField]
    private bool InvertY = false;
    [SerializeField]
    private float defaultZoom = 2.0f;
    [SerializeField]
    private float minZoomOut = 1.0f;
    [SerializeField]
    private float maxZoomOut = 3.0f;
    [SerializeField]
    private float zoomSpeed = 0.5f; // Smooths camera movement.
    [SerializeField]
    private float zoomRate = 0.5f; // Tolerance of scroll wheel.
    [SerializeField]
    private List<float> defaultRigRadius;
    private CinemachineFreeLook freeLookComponent;
    private ThirdPersonCharacter playerController;
    const int NUMBER_OF_RIGS = 3;
    private float currentZoomOut;
    private bool playerControlled = false;
    private GradualAction zoomAction;

    CinemachineComposer comp;

    void Start() 
    {
        freeLookComponent = GetComponent<CinemachineFreeLook>();
        
        // Listen for when player starts and stops moving.
        PlayerManager.Instance.Player.GetComponent<ThirdPersonCharacter>().onMovementChanged += SetCameraCentering;
        freeLookComponent.m_CommonLens = false;
        
        InputManager.Instance.Controls.Camera.Aim.started += _ => Aim();
        InputManager.Instance.Controls.Camera.Aim.canceled += _ => UnAim();
        InputManager.Instance.Controls.Camera.EnablePlayerControl.started += ctx => SetPlayerControl(true);
        InputManager.Instance.Controls.Camera.EnablePlayerControl.canceled += ctx => SetPlayerControl(false);
        InputManager.Instance.Controls.Camera.Zoom.performed += ctx => Zoom(ctx.ReadValue<Vector2>().normalized.y);

        // Set default zoom.
        currentZoomOut = defaultZoom;
        UpdateRigRadius(currentZoomOut);
    }

    void Update()
    {
        if(playerControlled)
        {
            ControlCamera();
        }
    }

    private void SetPlayerControl(bool enable)
    {
        playerControlled = enable;
    }

    private void ControlCamera()
    {
        float yRotation = InputManager.Instance.Controls.Camera.Pitch.ReadValue<float>();
        float xRotation = InputManager.Instance.Controls.Camera.Yaw.ReadValue<float>();

        yRotation = InvertY ? -yRotation : yRotation;
        // This is because X axis is only contains between -180 and 180 instead of 0 and 1 like the Y axis.
        xRotation = xRotation * 180f;

        // Adjust axis values using look speed and Time.deltaTime so the look doesn't go faster if there is more FPS.
        freeLookComponent.m_XAxis.Value += xRotation * LookSpeed * Time.deltaTime;
        freeLookComponent.m_YAxis.Value += yRotation * LookSpeed * Time.deltaTime;
    }

    private void Zoom(float zoomInput)
    {
        if(zoomAction == null || zoomAction.IsDone())
        {
            float startingZoom = currentZoomOut;
            currentZoomOut -= zoomInput * zoomRate;
            currentZoomOut = Mathf.Clamp(currentZoomOut, minZoomOut, maxZoomOut);

            // Update camera's zoom gradually based on zoom rate.
            zoomAction = new GradualAction(UpdateRigRadius, startingZoom, currentZoomOut, zoomSpeed);
            ActionManager.Instance.Add(zoomAction);
        } // else ignore input when zoom action is running.
    }

    private void UpdateRigRadius(float radius)
    {        
        // Apply new field of view to each camera rig.
        for (int i = 0; i < NUMBER_OF_RIGS; ++i)
        {
            freeLookComponent.m_Orbits[i].m_Radius = defaultRigRadius[i] * radius;
        }
    }

    private void UpdateFieldOfView(float fov)
    {
        // Apply new field of view to each camera rig.
        for (int i = 0; i < NUMBER_OF_RIGS; ++i)
        {
            freeLookComponent.GetRig(i).m_Lens.FieldOfView = fov;
        }
    }

    private void SetCameraCentering(bool enable)
    {
        freeLookComponent.m_YAxisRecentering.m_enabled = enable;
        freeLookComponent.m_RecenterToTargetHeading.m_enabled = enable;
    }

    private void Aim()
    {
        Debug.Log("Aiming");
    }

    private void UnAim()
    {
        Debug.Log("UnAiming");
    }
}