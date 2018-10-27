using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {
    bool nearInteractableObject = false;
    GameObject obj;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetButtonDown("Fire1") && nearInteractableObject)
        {
            if (obj != null)
            {
                var a = obj.gameObject.GetComponent<tmp_Intractable>();
                a.IntractableObjectDescription();
            }
            else
                Debug.Log("Didn't find a Object Description");
        }
        Debug.Log(nearInteractableObject);
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Intractable")
        {
            obj = other.gameObject;
        }
    }

    public void ToggleNearInteractableObject(bool toggle)
    {
        nearInteractableObject = toggle;
    }

    public void Intactable(GameObject intractableObj)
    {
        obj = intractableObj;
    }
    public void RemoveIntractable()
    {
        obj = null;
    }
}
