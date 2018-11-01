using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tmp_Intractable : MonoBehaviour {
    PlayerInteraction player;
    public GameObject itemGameObject;
    Item item;
    bool hasItem;
    public string description;

    // Use this for initialization
    void Start () {
        if (itemGameObject == null)
        {
            hasItem = false;
        }
        else
        {
            item = itemGameObject.GetComponent<Item>();
            hasItem = true;
        }    
	}
	
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("pelaaja on alueella");
            Journal.Instance.Log("Press Action button");
            Journal.Instance.ToggleImageBox(true);
            player = other.gameObject.GetComponent<PlayerInteraction>();
            player.ToggleNearInteractableObject(true);
            player.Intactable(this.gameObject);
            GiveItem();
        }   
        
    }

    public void GiveItem()
    {
        if(hasItem)
        {
            Inventory.Instance.AddItem(itemGameObject);
            RemoveItem();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Journal.Instance.Log("");
            Journal.Instance.ToggleImageBox(false);
            player = other.gameObject.GetComponent<PlayerInteraction>();
            player.ToggleNearInteractableObject(false);
            player.RemoveIntractable();
        }
    }
    public void IntractableObjectDescription()
    {
        Journal.Instance.Log(description);
    }

    public void RemoveItem()
    {
        itemGameObject = null;
        hasItem = false;
    }
}
