using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour {
    #region Singleton
    public static EquipmentManager instance;
    public Equipment[] defaultItems;
    public enum MeshBlendShape { Weapon, KeyItem, Tool };
    public SkinnedMeshRenderer targetMesh;
    SkinnedMeshRenderer[] currentMeshes;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    
 
    Equipment[] curretEquipment;
    Equipment currentEquip;
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
        // Find out what slot the item fits in
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
        currentEquip = newItem;
        ReturnCurrentEquipment();

        //Uusi toteutus
        /* GameObject newObject = Instantiate<GameObject>(newItem.obj);
         newObject.transform.parent = targetMesh.transform;*/


        /*SkinnedMeshRenderer newMesh = newObject.gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
        newMesh.bones = targetMesh.bones;
        newMesh.rootBone = targetMesh.rootBone;*/

        /*SkinnedMeshRenderer[] newMeshs = newObject.gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();

        foreach (SkinnedMeshRenderer mesh in newMeshs)
        {
            Debug.Log(mesh.name);
            if(mesh.tag == "MainMesh")
            {
                mesh.transform.parent = targetMesh.transform;
                mesh.bones = targetMesh.bones;
                mesh.rootBone = targetMesh.rootBone;
                mesh.transform.position = new Vector3(0, 0, 0);
                currentMeshes[slotIndex] = mesh;
            }
            
        }*/

        //orggis toteutus

        SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(newItem.mesh);

        newMesh.transform.parent = targetMesh.transform;
        newMesh.bones = targetMesh.bones;
        newMesh.rootBone = targetMesh.rootBone;

        //Disabloi boxcollider

        //newMesh.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        //newMesh.transform.Rotate (new Vector3(90, 90, 90),Space.World);
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

    public Equipment ReturnCurrentEquipment()
    {
        if (currentEquip != null)
        {
            return currentEquip;
        }
        else
            return null;
    }



}
