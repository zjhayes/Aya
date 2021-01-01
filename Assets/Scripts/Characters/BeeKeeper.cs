using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeKeeper : MonoBehaviour
{
    [SerializeField]
    private Camera camera;
    [SerializeField]
    private GameObject beePrefab;

    private List<GameObject> bees;
    private bool isAiming;

    void Start()
    {
        // Set player controls.
        InputManager.instance.Controls.Interact.Shoot.performed += ctx => ReleaseBee();
        InputManager.instance.Controls.Camera.Aim.started += ctx => isAiming = true;
        InputManager.instance.Controls.Camera.Aim.canceled += ctx => isAiming = false;

        bees = new List<GameObject>();
    }

    public void SpawnBee(Vector3 startPosition)
    {
        GameObject bee = Instantiate(beePrefab, startPosition, Quaternion.identity);
        bees.Add(bee);
    }

    private void ReleaseBee()
    {
        Vector3 targetPoint;

        if(isAiming)
        {
            targetPoint = GetTargetPosition();
        }
        else
        {
            Transform playerTransform = PlayerManager.instance.Player.transform;
            targetPoint = playerTransform.position + playerTransform.forward;
        }
        // New target
        
    }

    private Vector3 GetTargetPosition()
    {
        // Create a ray from the camera going through the middle of screen.
        Ray ray = camera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            return hit.point;
        else
            return ray.GetPoint(1000);
    }
}
