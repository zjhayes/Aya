using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attunable))]
[RequireComponent(typeof(BeeInteractable))]
public class BeehiveController : MonoBehaviour
{
    [SerializeField]
    private Vector3 spawnOffset;
    [SerializeField]
    private float spawnDelay = 5.0f;
    [SerializeField]
    private int beeCapacity = 3;

    private Attunable attunable;
    private BeeKeeper keeper;
    private Cooldown cooldown;

    void Start()
    {
        attunable = GetComponent<Attunable>();
        attunable.onAttuned += Attune;

        keeper = PlayerManager.instance.Player.GetComponent<BeeKeeper>();

        cooldown = new Cooldown(spawnDelay);

        GetComponent<BeeInteractable>().onBeeInteractable += ReturnHome;
    }

    private void Attune()
    {
        if(cooldown.IsReady && beeCapacity > 0)
        {
            Vector3 position = new Vector3(transform.position.x + spawnOffset.x, transform.position.y + spawnOffset.y, transform.position.z + spawnOffset.z);
            keeper.SpawnBee(position);
            beeCapacity--;
            cooldown.Begin();
        }
    }

    private void ReturnHome()
    {
        // If bee is dismissed, return home.
        GameObject bee = GetComponent<BeeInteractable>().Bee;
        if(bee.GetComponent<BeeController>().IsDismissed)
        {
            bee.GetComponent<BeeController>().FadeToDestroy();
            beeCapacity++;
        }
    }
}

/** Ensure Beehive Capsule Collider is centered on the ground. **/