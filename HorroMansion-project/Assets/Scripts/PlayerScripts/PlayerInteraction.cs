using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInteraction : MonoBehaviour {

    public Interactable focus;

    private void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit,3))
            {
                
               Interactable interactable = hit.collider.GetComponent<Interactable>();
                if(interactable != null)
                {
                    SetFocus(interactable);
                    Debug.DrawLine(ray.origin, hit.point);
                }
            }
        }
    }
    void SetFocus(Interactable newFocus)
    {
        if(newFocus != focus)
        {
            if(focus != null)
                focus.DeFocused();

            focus = newFocus;
        }
        
        newFocus.Onfocused(transform);
    }

    //Keksi miten päästää tästä tilanteessa pois
    void RemoveFocus()
    {
        if(focus != null)
            focus.DeFocused();

        focus = null;
    }

    /*
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
    */
}
