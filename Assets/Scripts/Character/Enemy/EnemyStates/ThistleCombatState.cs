using System.Collections.Generic;
using UnityEngine;

public class ThistleCombatState : CombatState
{
    [SerializeField]
    private float movementSpeed = 0.5f;
    [SerializeField]
    private float followOffset = 0.0f;
    [SerializeField]
    private GameObject linePointPrefab;
    [SerializeField]
    private float stemPointDelay = 3.0f;
    [SerializeField]
    private int maxStemPoints = 10;

    Stack<GameObject> stemPoints;
    Cooldown stemPointGenerationCooldown;

    void Start()
    {
        stemPoints = new Stack<GameObject>();
        stemPointGenerationCooldown = new Cooldown(stemPointDelay);
        stemPointGenerationCooldown.Begin();
    }

    public override void Update()
    {
        base.Update();

        if(stemPoints.Count <= maxStemPoints && stemPointGenerationCooldown.IsReady)
        {
            CreateStemPoint();
            stemPointGenerationCooldown.Begin();
        }
        controller.transform.position += controller.transform.forward * Time.deltaTime * movementSpeed;
    }

    private void CreateStemPoint()
    {
        GameObject stemPoint = (GameObject) Instantiate(linePointPrefab, transform.position, Quaternion.identity);
        stemPoints.Push(stemPoint);
        stemPoint.transform.parent = transform.parent; // Make sibling of thistle head.
        stemPoint.transform.SetSiblingIndex(1);
    }

    protected override Vector3 CalculateRotation(Vector3 direction)
    {
        return new Vector3(direction.x, direction.y + followOffset, direction.z);
    }
}
