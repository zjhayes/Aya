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
        PlayerManager.Instance.Stats.Heal(healingAmount);
        PlayerManager.Instance.Player.transform.position = location;
    }
}
