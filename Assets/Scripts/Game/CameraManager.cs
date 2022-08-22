using UnityEngine;

public class CameraManager : Singleton<CameraManager>
{
    [SerializeField]
    GameObject cameraRig;

    void Start()
    {
        // Set main camera transform.
        /*if (Camera.main != null)
        {
            camera = Camera.main.transform;
        }
        else
        {
            Debug.LogWarning(
                "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
            // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
        }*/
    }

    public Transform Camera
    {
        get { return Camera.transform; }
    }

    public GameObject CameraRig
    {
        get { return cameraRig; }
        private set { cameraRig = value; }
    }
}
