using System.Collections.Generic;
using UnityEngine;

public class StemManager : MonoBehaviour
{
    [SerializeField]
    private GameObject linePointPrefab;
    [SerializeField]
    private int maxStemPoints = 10;

    Stack<GameObject> stemPoints;

    void Awake()
    {
        stemPoints = new Stack<GameObject>();
    }

    public void CreateStemPoint()
    {
        if (stemPoints.Count <= maxStemPoints)
        {
            GameObject stemPoint = (GameObject)Instantiate(linePointPrefab, transform.position, Quaternion.identity);
            stemPoints.Push(stemPoint);
            stemPoint.transform.parent = transform.parent; // Make sibling of thistle head.
            stemPoint.transform.SetSiblingIndex(1);
        }
    }

    public void EnableGravity()
    {
        foreach(GameObject stemPoint in stemPoints)
        {

        }
    }
}
