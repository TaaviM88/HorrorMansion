using System;
using UnityEngine;

public class ItemPickUp : Interactable {

    public ItemB item;

    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    private void PickUp()
    {
        Debug.Log("Picking up " + item.name);
        bool wasPickedUp =  InventoryB.instance.AddItem(item);

        if(wasPickedUp)
            Destroy(gameObject);
    }
}
