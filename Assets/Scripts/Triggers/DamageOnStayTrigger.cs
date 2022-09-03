using UnityEngine;

public class DamageOnStayTrigger : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;

    void OnTriggerStay(Collider other) 
    {
        CharacterStats targetStats = other.GetComponent<CharacterStats>();
        if(targetStats != null)
        {
            targetStats.TakeDamage(damage);
        }
    }
}
