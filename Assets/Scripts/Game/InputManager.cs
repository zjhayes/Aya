using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    private PlayerInput controls;

    public PlayerInput Controls
    {
        get { return controls; }
    }

    void Awake()
    {
        if (controls == null) { controls = new PlayerInput(); }
    }

    void OnEnable()
    {
        // Turn controls on for this object.
        controls.Enable();
    }

    void OnDisable()
    {
        // Turn controls off for this object.
        controls.Disable();
    }
}
