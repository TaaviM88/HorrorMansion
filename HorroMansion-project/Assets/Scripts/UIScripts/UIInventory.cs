using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class UIInventory : MonoBehaviour {
    public List<UIItem> uiItems = new List<UIItem>();
    public GameObject slotPrefab;
    public Transform slotPanel;
    public static UIInventory Instance { get; set; }
    // Use this for initialization
    void Awake ()
    {

        
	}

    public void AddPanel()
    {
        if (Inventory.Instance.GetItemsCount() != 0)
        {
            for (int i = 0; i < Inventory.Instance.GetItemsCount(); i++)
            {
                GameObject instance = Instantiate(slotPrefab);
                instance.transform.SetParent(slotPanel);
                uiItems.Add(instance.GetComponentInChildren<UIItem>());
            }
        }
    }

    public void UpdateSlot(int slot, Item item)
    {
        uiItems[slot].UpdateItem(item);   
    }

    public void AddNewItem(Item item)
    {
        UpdateSlot(uiItems.FindIndex(i => i.item == null), item);
    }

    public void RemoveItem(Item item)
    {
        UpdateSlot(uiItems.FindIndex(i => i.item == item), null);
    }
}
