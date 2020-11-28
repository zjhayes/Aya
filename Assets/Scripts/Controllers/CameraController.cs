using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CinemachineFreeLook))]
public class CameraController : MonoBehaviour
{
    [SerializeField]
    [Range(0f, 10f)] 
    private float LookSpeed = 1f;
    [SerializeField]
    private bool InvertY = false;
    private CinemachineFreeLook freeLookComponent;

    void Start() 
    {
        freeLookComponent = GetComponent<CinemachineFreeLook>();
    }

    void Update()
    {
        float yRotation = InputManager.instance.Controls.Camera.Pitch.ReadValue<float>();
        float xRotation = InputManager.instance.Controls.Camera.Yaw.ReadValue<float>();

        yRotation = InvertY ? -yRotation : yRotation;
        // This is because X axis is only contains between -180 and 180 instead of 0 and 1 like the Y axis.
        xRotation = xRotation * 180f;

        //Adjust axis values using look speed and Time.deltaTime so the look doesn't go faster if there is more FPS.
        freeLookComponent.m_XAxis.Value += xRotation * LookSpeed * Time.deltaTime;
        freeLookComponent.m_YAxis.Value += yRotation * LookSpeed * Time.deltaTime;
    }
}   