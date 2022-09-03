using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterCombat))]
[RequireComponent(typeof(CharacterStats))]
public abstract class CharacterController : MonoBehaviour, IController
{
    protected CharacterStats stats;
    protected CharacterCombat combat;
    protected Animator animator;

    public CharacterStats Stats { get { return stats; } }
    public CharacterCombat Combat { get { return combat; } }
    public Animator Animator { get { return animator; } }
}
