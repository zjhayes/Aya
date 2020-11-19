using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    private void Awake() 
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found.");
            return;
        }

        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    
    [SerializeField]
    private List<Item> items = new List<Item>();
    [SerializeField]
    private int space = 20;

    public List<Item> Items
    {
        get{ return items; }
    }

    public bool Add(Item item)
    {
        if(!item.IsDefaultItem)
        {
            if(items.Count >= space)
            {
                Debug.Log("Not enough space in inventory.");
                return false;
            }
            items.Add(item);

            if(onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }
        }
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);

        if(onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
}
