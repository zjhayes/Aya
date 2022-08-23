using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    Vector3 location;

    void Start()
    {
        location = transform.position;
    }

    public void Restore()
    {
        PlayerManager.Instance.Player.transform.position = location;
    }
}
