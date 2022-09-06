using UnityEngine;

[RequireComponent(typeof(StemManager))]
[RequireComponent(typeof(Attunable))]
public class ThistleCombatState : CombatState
{
    [SerializeField]
    private float movementSpeed = 0.5f;
    [SerializeField]
    private float followOffset = 0.0f;
    [SerializeField]
    private float stemPointDelay = 3.0f; // Time between setting line point.
    [SerializeField]
    private float retractSpeed = 1.0f; // Rate stem retracts when damaged.

    StemManager stem;
    Attunable attunable;
    Cooldown stemPointGenerationCooldown;

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
        stem.RetractStem(retractSpeed);
        stemPointGenerationCooldown.Begin();
    }

    // Override FaceTarget calculation to enable Y axis movement.
    protected override Vector3 CalculateRotation(Vector3 direction)
    {
        return new Vector3(direction.x, direction.y + followOffset, direction.z);
    }
}
