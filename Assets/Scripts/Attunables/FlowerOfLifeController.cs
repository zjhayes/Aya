using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Attunable))]
[RequireComponent(typeof(Checkpoint))]
[RequireComponent(typeof(BeeInteraction))]
public class FlowerOfLifeController : MonoBehaviour
{
    [SerializeField]
    int healingAmount = 100;
    private Animator animator;
    private Attunable attunable;
    
    void Start()
    {
        animator = GetComponent<Animator>();

        attunable = GetComponent<Attunable>();
        attunable.onAttuned += Attune;

        GetComponent<BeeInteraction>().onBeeInteraction += Pollinate;
    }

    private void Attune()
    {
        if(animator.GetBool("IsPollinated"))
        {
            animator.SetTrigger("Attune");
            // Heal player and set checkpoint.
            PlayerManager.instance.Stats.Heal(healingAmount);
            PlayerManager.instance.Checkpoint = GetComponent<Checkpoint>();
        }
    }

    private void Pollinate()
    {
        Debug.Log("Pollinated");
    }
}
