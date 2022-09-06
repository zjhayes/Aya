using UnityEngine;

[RequireComponent(typeof(StemManager))]
[RequireComponent(typeof(Attunable))]
public class ThistleCombatState : CombatState
{
    [SerializeField]
    private float movementSpeed = 0.5f;
    [SerializeField]
    private float retractSpeed = 1.0f;
    [SerializeField]
    private float followOffset = 0.0f;
    [SerializeField]
    private float stemPointDelay = 3.0f;

    StemManager stem;
    Attunable attunable;
    Cooldown stemPointGenerationCooldown;
    MoveAction updatePositionAction;
    RotateAction updateRotationAction;

    protected override void Awake()
    {
        base.Awake();
        stem = GetComponent<StemManager>();
        attunable = GetComponent<Attunable>();
    }

    void Start()
    {
        base.Start();
        stemPointGenerationCooldown = new Cooldown(stemPointDelay);
        stemPointGenerationCooldown.Begin();
        attunable.onAttuned += Attune;
    }

    public override void Update()
    {
        base.Update();

        if(stemPointGenerationCooldown.IsReady)
        {
            stem.CreateStemPoint();
            stemPointGenerationCooldown.Begin();
        }
        controller.transform.position += controller.transform.forward * Time.deltaTime * movementSpeed;
    }

    private void Attune()
    {
        if(stem.StemPoints.Count > 0)
        {
            RetractStem();
        }
        else
        {
            // TODO: Return to origins
        }
    }

    private void RetractStem()
    {
        GameObject stemPoint = stem.StemPoints.Pop();

        // Retract stem by gradually updating position/rotation to previous stem point.
        updatePositionAction?.Cancel();
        updatePositionAction = new MoveAction(controller.transform, stemPoint.transform.position, retractSpeed);
        ActionManager.Instance.Add(updatePositionAction);

        updateRotationAction?.Cancel();
        updateRotationAction = new RotateAction(controller.transform, stemPoint.transform.rotation, retractSpeed);
        ActionManager.Instance.Add(updateRotationAction);

        // Destroy stem point and reset cooldown.
        Destroy(stemPoint);
        stemPointGenerationCooldown.Begin();
    }

    // Override FaceTarget calculation to enable Y axis movement.
    protected override Vector3 CalculateRotation(Vector3 direction)
    {
        return new Vector3(direction.x, direction.y + followOffset, direction.z);
    }

    public override void Disable()
    {
        base.Disable();
        stemPointGenerationCooldown?.Cancel();
        updatePositionAction?.Cancel();
        updateRotationAction?.Cancel();
    }
}
