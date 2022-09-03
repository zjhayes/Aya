using UnityEngine;

[RequireComponent(typeof(Attunable))]
public class DamageOnAttune : MonoBehaviour
{
    [SerializeField]
    private CharacterController controller;

    private CharacterStats playerStats;
    private Attunable attunable;

    void Awake()
    {
        attunable = GetComponent<Attunable>();
    }

    void Start()
    {
        playerStats = PlayerManager.Instance.Player.GetComponent<CharacterStats>();
        attunable.onAttuned += Attune;
    }

    private void Attune()
    {
        // Cause damage on attunement, assumes player triggered attunement.
        if (playerStats)
        {
            controller.Stats.TakeDamage(playerStats.Damage.Value);
        }
    }
}
