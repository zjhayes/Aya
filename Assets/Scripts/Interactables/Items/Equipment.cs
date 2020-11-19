using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    [SerializeField]
    private EquipmentSlot equipmentSlot;
    [SerializeField]
    private int armorModifier;
    [SerializeField]
    private int damageModifier;
    [SerializeField]
    private SkinnedMeshRenderer mesh;
    [SerializeField]
    private MeshRegion[] coveredRegions;

    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);
        RemoveFromInventory();
    }

    public EquipmentSlot EquipmentSlot
    {
        get { return equipmentSlot; }
    }

    public int ArmorModifier
    {
        get { return armorModifier; }
    }

    public int DamageModifier
    {
        get { return damageModifier; }
    }

    public SkinnedMeshRenderer Mesh
    {
        get { return mesh; }
    }

    public MeshRegion[] CoveredRegions
    {
        get { return coveredRegions; }
    }
}

public enum EquipmentSlot
{
    Head,
    Chest,
    Legs,
    Weapon,
    Sheild,
    Feet
}

// Corresponds to body blend shapes.
public enum MeshRegion
{
    Head,
    Torso,
    Arms,
    Legs
}