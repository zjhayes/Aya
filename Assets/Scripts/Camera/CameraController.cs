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
    private float zoomRate = 0.5f;
    [SerializeField]
    private List<int> zoomLevels;
    [SerializeField]
    private int startingIndex;
    private CinemachineFreeLook freeLookComponent;
    private ThirdPersonCharacter playerController;
    const int NUMBER_OF_RIGS = 3;
    private int zoomLevelIndex;
    private bool playerControlled = false;

    CinemachineComposer comp;

    void Start() 
    {
        freeLookComponent = GetComponent<CinemachineFreeLook>();
        zoomLevelIndex = startingIndex;
        
        // Listen for when player starts and stops moving.
        PlayerManager.Instance.Player.GetComponent<ThirdPersonCharacter>().onMovementChanged += SetCameraCentering;
        freeLookComponent.m_CommonLens = false;
        
        InputManager.Instance.Controls.Camera.ChangeView.performed += _ => ToggleView();
        InputManager.Instance.Controls.Camera.Aim.started += _ => Aim();
        InputManager.Instance.Controls.Camera.Aim.canceled += _ => UnAim();
        InputManager.Instance.Controls.Camera.EnablePlayerControl.started += ctx => SetPlayerControl(ctx.started);
        InputManager.Instance.Controls.Camera.EnablePlayerControl.canceled += ctx => SetPlayerControl(false);
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

    private void ToggleView()
    {
        int currentFOV = zoomLevels[zoomLevelIndex];
        zoomLevelIndex++;
        if(zoomLevelIndex >= zoomLevels.Count)
        {
            zoomLevelIndex = 0;
        }

        // Update camera's field of view gradually based on zoom rate.
        GradualAction zoom = new GradualAction(UpdateFieldOfView, currentFOV, zoomLevels[zoomLevelIndex], zoomRate);
        ActionManager.Instance.Add(zoom);
    }

    private void UpdateFieldOfView(float zoom)
    {
        // Apply new field of view to each camera rig.
        for (int i = 0; i < NUMBER_OF_RIGS; ++i)
        {
            freeLookComponent.GetRig(i).m_Lens.FieldOfView = zoom;
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