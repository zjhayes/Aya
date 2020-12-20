using UnityEngine;

public class Attunable : MonoBehaviour
{
    public delegate void OnAttuned();
    public OnAttuned onAttuned;

    public void Attune()
    {
        if(onAttuned != null)
        {
            onAttuned.Invoke();
        }
    }
}
