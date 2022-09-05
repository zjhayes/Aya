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
    private float stemPointDelay = 3.0f;

    StemManager stem;
    Cooldown stemPointGenerationCooldown;
    Attunable attunable;

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
        // push head back to edge of attune
        // destroy stem points in attune
        if(stem.StemPoints.Count > 0)
        {
            GameObject stemPoint = stem.StemPoints.Pop();
            transform.position = stemPoint.transform.position;
            transform.rotation = stemPoint.transform.rotation;
            Destroy(stemPoint);
            stemPointGenerationCooldown.Begin();
        }
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
