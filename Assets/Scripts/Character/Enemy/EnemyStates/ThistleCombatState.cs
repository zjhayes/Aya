using UnityEngine;

public class ThistleCombatState : CombatState
{
    [SerializeField]
    private float movementSpeed = 0.5f;

    public override void Update()
    {
        base.Update();

        controller.transform.position += controller.transform.forward * Time.deltaTime * movementSpeed;
    }
}
