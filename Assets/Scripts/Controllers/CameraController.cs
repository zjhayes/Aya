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

    CinemachineComposer comp;

    void Start() 
    {
        freeLookComponent = GetComponent<CinemachineFreeLook>();
        zoomLevelIndex = startingIndex;
        
        // Listen for when player starts and stops moving.
        PlayerManager.instance.Player.GetComponent<ThirdPersonCharacter>().onMovementChanged += EnableCameraCentering;
        freeLookComponent.m_CommonLens = false;
        
        InputManager.instance.Controls.Camera.ChangeView.performed += ctx => ToggleView();
    }

    void Update()
    {
        float yRotation = InputManager.instance.Controls.Camera.Pitch.ReadValue<float>();
        float xRotation = InputManager.instance.Controls.Camera.Yaw.ReadValue<float>();

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
        ActionManager.instance.Add(zoom);
    }

    private void UpdateFieldOfView(float zoom)
    {
        // Apply new field of view to each camera rig.
        for (int i = 0; i < NUMBER_OF_RIGS; ++i)
        {
            freeLookComponent.GetRig(i).m_Lens.FieldOfView = zoom;
        }
    }

    private void EnableCameraCentering(bool enable)
    {
        freeLookComponent.m_YAxisRecentering.m_enabled = enable;
        freeLookComponent.m_RecenterToTargetHeading.m_enabled = enable;
    }
}