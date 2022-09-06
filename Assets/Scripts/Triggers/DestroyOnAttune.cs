using UnityEngine;

[RequireComponent(typeof(Attunable))]
public class DestroyOnAttune : MonoBehaviour
{
    Attunable attunable;

    void Awake()
    {
        attunable = GetComponent<Attunable>();
    }

    void Start()
    {
        attunable.onAttuned += Attune;
    }

    private void Attune()
    {
        Destroy(this.gameObject);
    }
}
