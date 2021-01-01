using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeKeeper : MonoBehaviour
{
    [SerializeField]
    private Camera camera;
    [SerializeField]
    private GameObject beePrefab;
    [SerializeField]
    private GameObject beeTarget;
    [SerializeField]
    private float targetDistance = 5.0f;

    private Queue<GameObject> bees;
    private bool isAiming;

    void Start()
    {
        // Set player controls.
        InputManager.instance.Controls.Interact.Shoot.performed += ctx => ReleaseBee();
        InputManager.instance.Controls.Camera.Aim.started += ctx => isAiming = true;
        InputManager.instance.Controls.Camera.Aim.canceled += ctx => isAiming = false;

        bees = new Queue<GameObject>();
    }

    public void SpawnBee(Vector3 startPosition)
    {
        GameObject bee = Instantiate(beePrefab, startPosition, Quaternion.identity);
        bees.Enqueue(bee);
    }

    private void ReleaseBee()
    {
        if(bees.Count == 0) { return; } // No bees. 

        Vector3 targetPoint;
        Transform playerTransform = PlayerManager.instance.Player.transform;

        if(isAiming)
        {
            targetPoint = GetTargetPosition();
        }
        else
        {
            // Get position in front of player.
            targetPoint = playerTransform.position + playerTransform.forward * targetDistance;
        }

        GameObject target = Instantiate(beeTarget, targetPoint, playerTransform.rotation);
        
        // Release bee to target.
        GameObject bee = bees.Dequeue();
        bee.GetComponent<TargetManager>().Target = target.transform;
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
