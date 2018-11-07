using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour {
   public List<GameObject> items = new List<GameObject>();
    public List<UIItem> uiItems = new List<UIItem>();   
    public static Inventory Instance { get; set; }

    //Ui-stuff
    public GameObject slotPrefab;
    public Transform slotPanel;
    // Use this for initialization
    void Awake () {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
            Instance = this;
    }

    private void Update()
    {
        if(items.Count > 0)
        {
            foreach(var item in items)
            {
                Debug.Log(item.name);
            }
        }
        
    }
    public void AddItem(GameObject item)
    {
        items.Add(item);
        GameObject instance = Instantiate(slotPrefab);
        instance.transform.SetParent(slotPanel);
        uiItems.Add(instance.GetComponentInChildren<UIItem>());
    }

    public void GetAllNames()
    {
        foreach(var item in items)
        {
            Debug.Log(item.name);
        }
    }

    public GameObject GetItem(int itemIdex)
    {
        GameObject returnedItem = items[itemIdex];
        return returnedItem;
    }

    public int GetItemsCount()
    {
        return items.Count;
    }
    //UI-stuff
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
