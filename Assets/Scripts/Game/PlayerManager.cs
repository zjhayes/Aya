﻿using System.Collections;
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
    private Checkpoint previousCheckpoint;

    public GameObject Player 
    {
        get { return player; }
    }

    public PlayerStats Stats
    {
        get { return stats; }
    }

    public Checkpoint Checkpoint
    {
        get { return previousCheckpoint; }
        set { this.previousCheckpoint = value;}
    }

    void Start()
    {
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
