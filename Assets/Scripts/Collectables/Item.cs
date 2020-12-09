using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    [SerializeField]
    new private string name = "New Item";
    [SerializeField]
    private Sprite icon = null;
    [SerializeField]
    private bool isDefaultItem = false;

    public virtual void Use()
    {
        Debug.Log("Using " + name);
    }

    public void RemoveFromInventory ()
	{
		Inventory.instance.Remove(this);
	}
    
    public string Name
    {
        get { return name; }
    }
    public Sprite Icon
    {
        get { return icon; }
    }
    public bool IsDefaultItem
    {
        get { return isDefaultItem; }
    }
}
