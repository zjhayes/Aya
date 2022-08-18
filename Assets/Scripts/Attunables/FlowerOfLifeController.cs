using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Attunable))]
[RequireComponent(typeof(Checkpoint))]
public class FlowerOfLifeController : MonoBehaviour
{
    [SerializeField]
    int healingAmount = 100;
    [SerializeField]
    private bool bloomed = false;
    private Animator animator;
    private Attunable attunable;
    Checkpoint checkpoint;

    const string BLOOM_STATE = "IsPollinated";
    const string ATTUNE_ANIMATION_TRIGGER = "Attune";
    
    void Start()
    {
        animator = GetComponent<Animator>();
        checkpoint = GetComponent<Checkpoint>();

        attunable = GetComponent<Attunable>();
        attunable.onAttuned += Attune;

        // Set default pollination state.
        UpdateBloomState();
    }

    private void Attune()
    {
        if(animator.GetBool(BLOOM_STATE))
        {
            animator.SetTrigger(ATTUNE_ANIMATION_TRIGGER);
            // Heal player and set checkpoint. TODO: Release healing orbs instead.
            PlayerManager.Instance.Stats.Heal(healingAmount);
            SetAsCheckpoint();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == PlayerManager.Instance.Player.tag)
        {
            // Set bloom state, and player checkpoint.
            bloomed = true;
            UpdateBloomState();
            SetAsCheckpoint();
        }
    }

    private void SetAsCheckpoint()
    {
        PlayerManager.Instance.Checkpoint = checkpoint;
    }

    private void UpdateBloomState()
    {
        animator.SetBool(BLOOM_STATE, bloomed);
    }
}
