using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    private Transform itemsParent;
    [SerializeField]
    private GameObject inventoryUI;

    private Inventory inventory;
    private InventorySlot[] slots;

    void Start()
    {
        inventory = Inventory.Instance;
        inventory.onItemChangedCallback = UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    void Awake() 
    {
        // Set inventory controls.
        InputManager.Instance.Controls.HUD.Inventory.performed += ctx => ToggleActive();
    }

    private void ToggleActive()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);
    }

    private void UpdateUI()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.Items.Count)
            {
                slots[i].AddItem(inventory.Items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
