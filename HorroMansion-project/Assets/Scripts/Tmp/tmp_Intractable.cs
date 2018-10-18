using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tmp_Intractable : MonoBehaviour {
    tmp_playermovement player;
    public GameObject Item;
    bool hasItem;
    public string description;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("pelaaja on alueella");
            Journal.Instance.Log("Press Action button");
            player = other.gameObject.GetComponent<tmp_playermovement>();
            player.TogglenearInteractableObject(true);
            player.Intractable(this.gameObject);


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Journal.Instance.Log("");
            player = other.gameObject.GetComponent<tmp_playermovement>();
            player.TogglenearInteractableObject(false);
            player.RemoveIntractable();
        }
    }
    public void IntractableObjectDescription()
    {
        Journal.Instance.Log(description);
    }
}
