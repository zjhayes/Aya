using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    #region Singleton
        public static InputManager instance;

        void Awake() 
        {
            instance = this;
            if(controls == null) { controls = new PlayerInput(); }
        }
    #endregion

    private PlayerInput controls;

    public PlayerInput Controls
    {
        get { return controls; }
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
