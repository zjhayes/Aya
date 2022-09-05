using UnityEngine;

[RequireComponent(typeof(StemManager))]
public class ThistleDeathState : DeathState
{
    StemManager stem;

    protected override void Awake()
    {
        base.Awake();
        stem = GetComponent<StemManager>();
    }

    protected override void Die()
    {
        base.Die();
        stem.EnableGravity(true);
    }
}
