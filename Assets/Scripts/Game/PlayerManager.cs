using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    #region Singleton
        public static PlayerManager instance;

        void Awake() 
        {
            if(instance != null)
            {
                Debug.LogWarning("More than one instance of PlayerManager found.");
                return;
            }
            instance = this;
        }
    #endregion

    [SerializeField]
    private GameObject player;
    private PlayerStats stats;

    public GameObject Player 
    {
        get { return player; }
    }

    public PlayerStats Stats
    {
        get { return stats; }
    }

    void Start()
    {
        stats = player.GetComponent<PlayerStats>();
    }

    public void KillPlayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
