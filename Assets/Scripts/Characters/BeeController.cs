using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(TargetManager))]
[RequireComponent(typeof(Renderer))]
public class BeeController : MonoBehaviour
{
    [SerializeField]
    private Vector3 followOffset;
    [SerializeField]
    private float fadeRate = 0.5f;
    [SerializeField]
    private List<GameObject> meshes;

    private TargetManager targetManager;
    private NavMeshAgent agent;
    private RendererUtility fader;
    private bool dismissed = false;

    public bool IsDismissed
    {
        get{ return dismissed; }
    }

    void Start()
    {
        targetManager = GetComponent<TargetManager>();
        targetManager.SetToPlayer();

        agent = GetComponent<NavMeshAgent>();

        // Add bee meshes to fader.
        fader = new RendererUtility();
        foreach(GameObject mesh in meshes)
        {
            fader.AddMesh(mesh.GetComponent<SkinnedMeshRenderer>());
        }
    }

    void Update()
    {
        if(!dismissed && targetManager.Target == null) 
        { 
            // No target, return home.
            Dismiss();
            return;
        }

        if(targetManager.Target != null)
        {
            Vector3 targetPosition = targetManager.Target.position;
            Vector3 destination = new Vector3(targetPosition.x + followOffset.x, targetPosition.y + followOffset.y, targetPosition.z + followOffset.z);
            if(destination != Vector3.zero)
            {
                agent.SetDestination(destination);
            }
        }

    }

    public void Dismiss()
    {
        dismissed = true;
        GameObject beehive = ObjectFinder.FindClosestObjectWithTag("Beehive", transform);
        if(beehive != null) 
        {
            targetManager.Target = beehive.transform;
        }
    }

    public void FadeToDestroy()
    {
        //Update alpha of object gradually based on fade rate, then destroy.
        GradualAction fade = new GradualAction(FadeOut, 100, 0, fadeRate);
        ActionManager.instance.Add(fade);
    }

    private void FadeOut(float newAlpha)
    {
        fader.UpdateAlpha(newAlpha);

        if(newAlpha <= 0)
        {
            Destroy(gameObject);
        }
    }
}
