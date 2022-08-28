using UnityEngine;

public class CombatState : MonoBehaviour, IState<EnemyController>
{
    EnemyController controller;

    void Start()
    {
        controller = GetComponent<EnemyController>();
    }

    void Update()
    {
        if (controller.TargetManager.HasTarget() && TargetIsInRange())
        {
            controller.Attack();
        }
    }

    public void Destroy()
    {
        Destroy(this);
    }

    private bool TargetIsInRange()
    {
        float distance = Vector3.Distance(controller.TargetManager.Target.transform.position, transform.position);
        if (distance <= controller.AttackRadius)
        {
            return true;
        }
        return false;
    }

    private void OnDrawGizmosSelected()
    {
        // Show enemy's visual radius in editor.
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, controller.AttackRadius);
    }
}
