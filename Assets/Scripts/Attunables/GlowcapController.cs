using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowcapController : MonoBehaviour
{
    [SerializeField]
    GameObject glowcap;
    [SerializeField]
    GameObject bottom;
    [SerializeField]
    private bool defaultStatus = false;
    MushroomController mushroomController;

    void Start()
    {
        // Access Mushroom perfab root > Mushroom Controller
        mushroomController = transform.parent.gameObject.GetComponent<MushroomController>();
        if(mushroomController != null)
        {
            mushroomController.onChargeUpdated += OnCharged;
        }
        OnCharged(defaultStatus);
    }

    void OnCharged(bool isCharged)
    {
        glowcap.SetActive(isCharged);
        bottom.SetActive(!isCharged);
    }
}