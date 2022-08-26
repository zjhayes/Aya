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
        // Turn controls on with this object.
        controls.Enable();
    }

    void OnDisable()
    {
        // Turn controls off with this object.
        controls.Disable();
    }
}
