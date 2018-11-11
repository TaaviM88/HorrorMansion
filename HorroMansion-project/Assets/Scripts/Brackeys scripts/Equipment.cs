using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : ItemB {

    public GameObject obj;
    public EquipmentSlot equipSlot;
    public EquipmentMeshRegion[] coveredMeshRegions;
    public SkinnedMeshRenderer mesh;
    public int armorModifier;
    public int damageModifier;

    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);
        RemoveFromInventory();
    }
}

public enum EquipmentSlot {Weapon, KeyItem, Tool }
public enum EquipmentMeshRegion {Arms } // Corresponds tobody blenshapes.
