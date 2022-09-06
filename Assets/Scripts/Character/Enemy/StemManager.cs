using System.Collections.Generic;
using UnityEngine;

public class StemManager : MonoBehaviour
{
    [SerializeField]
    private GameObject linePointPrefab;
    [SerializeField]
    private int maxStemPoints = 10;

    Stack<GameObject> stemPoints;
    MoveAction updatePositionAction;
    RotateAction updateRotationAction;
    Vector3 originalPosition;
    Quaternion originalRotation;

    public Stack<GameObject> StemPoints { get { return stemPoints; } }

    void Awake()
    {
        stemPoints = new Stack<GameObject>();
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    public void CreateStemPoint()
    {
        if (stemPoints.Count <= maxStemPoints)
        {
            GameObject stemPoint = (GameObject)Instantiate(linePointPrefab, transform.position, transform.rotation);
            stemPoints.Push(stemPoint);
            stemPoint.transform.parent = transform.parent; // Make sibling of thistle head.
            stemPoint.transform.SetSiblingIndex(1); // Must be positioned after head.
        }
    }

    public void RetractStem(float retractSpeed)
    {
        if(stemPoints.Count <= 0)
        {
            RetractToOrigin(retractSpeed);
            return; // Stem is fully retracted.
        }

        GameObject stemPoint = stemPoints.Pop();

        // Retract stem by gradually updating position/rotation to previous stem point.
        RetractPosition(stemPoint.transform.position, retractSpeed);
        RetractRotation(stemPoint.transform.rotation, retractSpeed);

        // Destroy stem point.
        Destroy(stemPoint);
    }

    private void RetractToOrigin(float retractSpeed)
    {
        RetractPosition(originalPosition, retractSpeed);
        RetractRotation(originalRotation, retractSpeed);
    }

    public void EnableGravity(bool enable)
    {
        foreach(GameObject stemPoint in stemPoints)
        {
            stemPoint.GetComponent<Rigidbody>().useGravity = enable;
            stemPoint.GetComponent<SphereCollider>().isTrigger = !enable;
        }
    }

    public bool IsRetracting()
    {
        return updatePositionAction != null && !updatePositionAction.IsDone();
    }

    private void RetractPosition(Vector3 targetPosition, float retractSpeed)
    {
        updatePositionAction?.Cancel();
        updatePositionAction = new MoveAction(UpdatePosition, transform.position, targetPosition, retractSpeed);
        ActionManager.Instance.Add(updatePositionAction);
    }

    private void RetractRotation(Quaternion targetRotation, float retractSpeed)
    {
        updateRotationAction?.Cancel();
        updateRotationAction = new RotateAction(UpdateRotation, transform.rotation, targetRotation, retractSpeed);
        ActionManager.Instance.Add(updateRotationAction);
    }

    private void UpdatePosition(Vector3 newPosition)
    {
        TransformUtility.UpdatePosition(transform, newPosition);
    }

    private void UpdateRotation(Quaternion newRotation)
    {
        TransformUtility.UpdateRotation(transform, newRotation);
    }
}
