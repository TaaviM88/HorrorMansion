using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour {
    #region Singleton
    public static EquipmentManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public Equipment[] defaultItems;
    public SkinnedMeshRenderer targetMesh;
    Equipment[] curretEquipment;
    SkinnedMeshRenderer[] currentMeshes;
    public delegate void OnEquipmenChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmenChanged onEquipmenChanged;
    InventoryB inventory;

    void Start()
    {
        inventory = InventoryB.instance;

        //Initialize currentEquipment based on number of equipment slots.
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        curretEquipment = new Equipment[numSlots];
        currentMeshes = new SkinnedMeshRenderer[numSlots];
        EquipDefaultItems();
    }

    public void Equip(Equipment newItem)
    {
        int slotIndex = (int)newItem.equipSlot;
        UnEquip(slotIndex);
        Equipment oldItem = UnEquip(slotIndex);

        //An item has been equipped so we trigger the callback
        if(onEquipmenChanged != null)
        {
            onEquipmenChanged.Invoke(newItem, oldItem);
        }

        SetEquipmentBlendShapes(newItem, 100);
        //Insert the item into the slot
        curretEquipment[slotIndex] = newItem;
        SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(newItem.mesh);
        newMesh.transform.parent = targetMesh.transform;
        newMesh.bones = targetMesh.bones;
        newMesh.rootBone = targetMesh.rootBone;
        //newMesh.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        newMesh.transform.Rotate (new Vector3(90, 90, 90),Space.World);
        currentMeshes[slotIndex] = newMesh;
    }

    public Equipment UnEquip(int slotIndex)
    {
        if(curretEquipment[slotIndex]!=null)
        {
            if(currentMeshes[slotIndex]!= null)
            {
                Destroy(currentMeshes[slotIndex].gameObject);
            }
            Equipment oldItem = curretEquipment[slotIndex];
            SetEquipmentBlendShapes(oldItem, 0);
            inventory.AddItem(oldItem);
            curretEquipment[slotIndex] = null;

            if (onEquipmenChanged != null)
            {
                onEquipmenChanged.Invoke(null, oldItem);
            }
            return oldItem;
        }
        return null;
    }

    public void UnequipAll()
    {
        for(int i = 0; i< curretEquipment.Length; i++)
        {
            UnEquip(i);
        }
        EquipDefaultItems();
    }

    void SetEquipmentBlendShapes(Equipment item,int weight)
    {
        foreach(EquipmentMeshRegion blendShape in item.coveredMeshRegions)
        {
            targetMesh.SetBlendShapeWeight((int)blendShape, weight);
        }
    }

    void EquipDefaultItems()
    {
        if(defaultItems != null)
        {
            foreach (Equipment item in defaultItems)
            {
                Equip(item);
            }
        }
        
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            UnequipAll();
            Debug.Log("otettiin kaikki varusteet pois päältä. Muuta toimimaan jollain muulla näppäimellä");
        }
    }

}
