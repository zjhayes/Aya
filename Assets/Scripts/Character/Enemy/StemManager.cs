using System.Collections.Generic;
using UnityEngine;

public class StemManager : MonoBehaviour
{
    [SerializeField]
    private GameObject linePointPrefab;
    [SerializeField]
    private int maxStemPoints = 10;

    Stack<GameObject> stemPoints;

    public Stack<GameObject> StemPoints { get { return stemPoints; } }

    void Awake()
    {
        stemPoints = new Stack<GameObject>();
    }

    public void CreateStemPoint()
    {
        if (stemPoints.Count <= maxStemPoints)
        {
            GameObject stemPoint = (GameObject)Instantiate(linePointPrefab, transform.position, transform.rotation);
            stemPoints.Push(stemPoint);
            stemPoint.transform.parent = transform.parent; // Make sibling of thistle head.
            stemPoint.transform.SetSiblingIndex(1);
        }
    }

    public void EnableGravity(bool enable)
    {
        foreach(GameObject stemPoint in stemPoints)
        {
            stemPoint.GetComponent<Rigidbody>().useGravity = enable;
            stemPoint.GetComponent<SphereCollider>().isTrigger = !enable;
        }
    }
}
