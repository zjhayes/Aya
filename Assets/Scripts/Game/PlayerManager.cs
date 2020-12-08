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

    public delegate void OnHealthChanged(int newHealth);
    public OnHealthChanged onHealthChanged;

    public GameObject Player 
    {
        get { return player; }
    }

    public void KillPlayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void DamageTaken(int damage, int currentHealth)
    {
        // Trigger onHealthChanged event.
        onHealthChanged.Invoke(currentHealth);
    }
}
