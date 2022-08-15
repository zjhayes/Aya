using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Attunable))]
[RequireComponent(typeof(Checkpoint))]
[RequireComponent(typeof(BeeInteractable))]
public class FlowerOfLifeController : MonoBehaviour
{
    [SerializeField]
    int healingAmount = 100;
    [SerializeField]
    private bool pollinated = false;
    private Animator animator;
    private Attunable attunable;
    private BeeInteractable beeInteraction;
    
    void Start()
    {
        animator = GetComponent<Animator>();

        attunable = GetComponent<Attunable>();
        attunable.onAttuned += Attune;

        beeInteraction = GetComponent<BeeInteractable>();
        beeInteraction.onBeeInteractable += Pollinate;

        // Set default pollination state.
        animator.SetBool("IsPollinated", pollinated);
        beeInteraction.IsEnabled = !pollinated;
    }

    private void Attune()
    {
        if(animator.GetBool("IsPollinated"))
        {
            animator.SetTrigger("Attune");
            // Heal player and set checkpoint.
            PlayerManager.Instance.Stats.Heal(healingAmount);
            PlayerManager.Instance.Checkpoint = GetComponent<Checkpoint>();
        }
    }

    private void Pollinate()
    {
        // Destroy bee, and stop further bee interactions.
        beeInteraction.Bee.GetComponent<BeeController>().FadeToDestroy();
        beeInteraction.IsEnabled = false;
        pollinated = true;
        animator.SetBool("IsPollinated", true);
    }
}
