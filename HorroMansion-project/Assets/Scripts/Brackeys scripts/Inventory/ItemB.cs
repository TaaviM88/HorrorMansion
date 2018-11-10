using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName = "Inventory/Item")]
public class ItemB : ScriptableObject {

    new public string name = "New item";
    public Sprite icon = null;
    public bool isDefaultItem = false;

    public virtual void Use()
    {
        // Debug.Log("Using " + name);
        Journal.Instance.Log("Using " + name);
    }

    public void RemoveFromInventory()
    {
        InventoryB.instance.RemoveItem(this);
    }
}
