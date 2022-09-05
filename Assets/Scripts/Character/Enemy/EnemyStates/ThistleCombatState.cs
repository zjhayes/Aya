using UnityEngine;

[RequireComponent(typeof(StemManager))]
public class ThistleCombatState : CombatState
{
    [SerializeField]
    private float movementSpeed = 0.5f;
    [SerializeField]
    private float followOffset = 0.0f;
    [SerializeField]
    private float stemPointDelay = 3.0f;

    StemManager stem;
    Cooldown stemPointGenerationCooldown;

    protected override void Awake()
    {
        base.Awake();
        stem = GetComponent<StemManager>();
    }

    void Start()
    {
        base.Start();
        stemPointGenerationCooldown = new Cooldown(stemPointDelay);
        stemPointGenerationCooldown.Begin();
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

    protected override Vector3 CalculateRotation(Vector3 direction)
    {
        return new Vector3(direction.x, direction.y + followOffset, direction.z);
    }

    public override void Disable()
    {
        base.Disable();
        stemPointGenerationCooldown?.Cancel();
    }
}
