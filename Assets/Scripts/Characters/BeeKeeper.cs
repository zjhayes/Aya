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
    [SerializeField]
    private float releaseDelay = 1.0f;

    private Queue<GameObject> bees;
    private Cooldown releaseCooldown;
    private bool isAiming = false;

    void Start()
    {
        // Set player controls.
        InputManager.instance.Controls.Interact.Shoot.performed += ctx => ReleaseBee();
        InputManager.instance.Controls.Camera.Aim.started += ctx => isAiming = true;
        InputManager.instance.Controls.Camera.Aim.canceled += ctx => isAiming = false;

        bees = new Queue<GameObject>();

        releaseCooldown = new Cooldown(releaseDelay);
    }

    public void SpawnBee(Vector3 startPosition, Quaternion startRotation)
    {
        GameObject bee = Instantiate(beePrefab, startPosition, startRotation);
        AddBee(bee);
    }

    public void AddBee(GameObject bee)
    {
        // Set target to player, and add to keeper.
        bee.GetComponent<TargetManager>().SetToPlayer();
        bee.GetComponent<BeeController>().SetStoppingDistance(2.0f);
        bee.GetComponent<BeeController>().SetSpeed(3.5f);
        bees.Enqueue(bee);
    }

    private void ReleaseBee()
    {
        if(bees.Count == 0) { return; } // No bees. 

        if(releaseCooldown.IsReady)
        {
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
            bee.GetComponent<BeeController>().SetStoppingDistance(0.0f);
            bee.GetComponent<BeeController>().SetSpeed(2.0f);
            bee.GetComponent<TargetManager>().Target = target.transform;
            
            releaseCooldown.Begin();
        }
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
