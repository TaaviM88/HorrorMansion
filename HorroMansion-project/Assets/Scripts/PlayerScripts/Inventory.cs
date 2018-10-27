using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
    List<GameObject> items = new List<GameObject>();
    public static Inventory Instance { get; set; }
    // Use this for initialization
    void Start () {
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
                Debug.Log(item);
            }
        }
        
    }
    public void AddItem(GameObject item)
    {
        items.Add(item);
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
}
