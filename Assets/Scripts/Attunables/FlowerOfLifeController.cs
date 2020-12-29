using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Attunable))]
public class FlowerOfLifeController : MonoBehaviour
{
    private Animator animator;
    private Attunable attunable;
    
    void Start()
    {
        animator = GetComponent<Animator>();

        attunable = GetComponent<Attunable>();
        attunable.onAttuned += Attune;
    }

    private void Attune()
    {
        if(animator.GetBool("IsPollinated"))
        {
            animator.SetTrigger("Attune");
        }
        // Heal
        // Save
    }
}
