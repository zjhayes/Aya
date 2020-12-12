using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
    #region Singleton
    public static ActionManager instance;

    void Awake() 
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of ActionManager found.");
            return;
        }

        instance = this;
        actions = new List<IAction>();
        pendingActions = new List<IAction>();

        CleanAll();
    }
    #endregion

    List<IAction> actions;
    List<IAction> pendingActions;

    void Update()
    {
        foreach(IAction action in actions)
        {
            action.Run();
        }
        Clean();
        AddPendingActions();
    }

    public void Add(IAction action)
    {
        pendingActions.Add(action);
    }

    private void AddPendingActions()
    {
        foreach(IAction action in pendingActions)
        {
            actions.Add(action);
        }
        pendingActions.Clear();
    }

    private void Clean()
    {
        List<IAction> actionsClone = actions.GetClone();
        foreach(IAction action in actionsClone)
        {
            if(action.IsDone())
            {
                actions.Remove(action);
            }
        }
    }

    public void CleanAll()
    {
        actions = new List<IAction>();
    }
}