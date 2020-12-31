using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Vector3 location;
    private int healingAmount = 100;
    void Start()
    {
        location = transform.position;
    }

    public void Restore()
    {
        PlayerManager.instance.Stats.Heal(healingAmount);
        PlayerManager.instance.Player.transform.position = location;
    }
}
