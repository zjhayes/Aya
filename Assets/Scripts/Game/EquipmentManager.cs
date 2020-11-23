using UnityEngine;
using System;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton
    public static EquipmentManager instance;

    void Awake() 
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of EquipmentManager found.");
            return;
        }

        instance = this;

        // Set equipment controls.
        InputManager.instance.Controls.Interact.UnequiptAll.performed += ctx => UnequipAll();
    }
    #endregion
    
    [SerializeField]
    private SkinnedMeshRenderer targetMesh; // Body mesh.
    [SerializeField]
    private Equipment[] defaultEquipment;
    private Equipment[] currentEquipment;
    private SkinnedMeshRenderer[] currentMeshes;
    private Inventory inventory;

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment olditem);
    public OnEquipmentChanged onEquipmentChanged;


    void Start()
    {
        inventory = Inventory.instance;

        // Set currentEquipment array size to number of EquipmentSlot enums.
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
        currentMeshes = new SkinnedMeshRenderer[numSlots];

        EquipDefaultItems();
    }

    public void Equip(Equipment newItem)
    {
        int slotIndex = (int) newItem.EquipmentSlot; // Index of EquipmentSlot enum.
        Equipment oldItem = Unequip(slotIndex);

        // An item has been equipped so we trigger the callback.
        if(onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }

        SetEquipmentBlendShapes(newItem, 100);

        // Insert item into inventory slot.
        currentEquipment[slotIndex] = newItem;

        // Update mesh.
        SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(newItem.Mesh);
        newMesh.transform.parent = targetMesh.transform;
        newMesh.bones = targetMesh.bones;
        newMesh.rootBone = targetMesh.rootBone;
        currentMeshes[slotIndex] = newMesh;
    }

    public Equipment Unequip(int slotIndex) 
    {
        if(currentEquipment[slotIndex] != null)
        {
            // Remove mesh.
            if(currentMeshes[slotIndex] != null)
            {
                Destroy(currentMeshes[slotIndex].gameObject);
            }

            // Add item to inventory if not default item.
            Equipment oldItem = currentEquipment[slotIndex];
            if(!Array.Exists(defaultEquipment, element => element.Name.Equals(oldItem.Name))) 
            {
                SetEquipmentBlendShapes(oldItem, 0); // Reset blend shapes.
                inventory.Add(oldItem);
            }

            // Remove item from equipment.
            currentEquipment[slotIndex] = null;

            if(onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem);
            }

            return oldItem;
        }
        return null;
    }

    private void UnequipAll()
    {
        for(int i = 0; i < currentEquipment.Length; i++)
        {
            Unequip(i);
        }
        EquipDefaultItems();
    }

    private void SetEquipmentBlendShapes(Equipment item, int weight)
    {
        foreach(MeshRegion blendShape in item.CoveredRegions)
        {
            targetMesh.SetBlendShapeWeight((int) blendShape, weight);
        }
    }

    private void EquipDefaultItems() 
    {
        foreach(Equipment item in defaultEquipment)
        {
            Equip(item);
        }
    }
}