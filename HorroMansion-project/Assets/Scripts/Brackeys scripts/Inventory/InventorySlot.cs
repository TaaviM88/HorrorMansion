using UnityEngine.UI;
using UnityEngine;

public class InventorySlot : MonoBehaviour {

    public Image icon;
    
    ItemB item;
    public void AddItem (ItemB newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;

    }
	
    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }

    public void OnRemoveButton()
    {
        InventoryB.instance.RemoveItem(item);
    }

    public void UseItem()
    {
        if(item != null)
        {
            item.Use();
        }
    }
}
