using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attunable))]
public class BeehiveController : MonoBehaviour
{
    [SerializeField]
    private Vector3 spawnOffset;
    [SerializeField]
    private float spawnDelay = 5.0f;

    private Attunable attunable;
    private BeeKeeper keeper;
    private Cooldown cooldown;

    void Start()
    {
        attunable = GetComponent<Attunable>();
        attunable.onAttuned += Attune;

        keeper = PlayerManager.instance.Player.GetComponent<BeeKeeper>();

        cooldown = new Cooldown(spawnDelay);
    }

    private void Attune()
    {
        if(cooldown.IsReady)
        {
            Vector3 position = new Vector3(transform.position.x + spawnOffset.x, transform.position.y + spawnOffset.y, transform.position.z + spawnOffset.z);
            keeper.SpawnBee(position);
            cooldown.Begin();
        }
    }
}
