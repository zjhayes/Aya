using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : Singleton<PlayerManager>
{
    [SerializeField]
    private GameObject player;
    private PlayerStats stats;
    private Checkpoint previousCheckpoint;

    public GameObject Player { get { return player; } }
    public PlayerStats Stats { get { return stats; } }
    public Checkpoint Checkpoint
    {
        get { return previousCheckpoint; }
        set { previousCheckpoint = value; }
    }

    protected override void Awake()
    {
        base.Awake();
        stats = player.GetComponent<PlayerStats>();
    }

    public void KillPlayer()
    {
        if(previousCheckpoint != null)
        {
            previousCheckpoint.Restore();
        }
        else
        {
            ActionManager.Instance.CleanAll();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
