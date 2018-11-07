using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryB : MonoBehaviour {

    #region Singleton
    public static InventoryB instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of InventoryB found!");
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 8;
    public List<ItemB> items = new List<ItemB>();

    public bool AddItem (ItemB item)
    {
        if(!item.isDefaultItem)
        {
            if(items.Count >= space)
            {
                Debug.Log("Not enough room");
                return false;
            }
            items.Add(item);

            if(onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }
        return true;
        
    }

    public void RemoveItem (ItemB item)
    {
        items.Remove(item);
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
