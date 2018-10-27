using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tmp_playermovement : MonoBehaviour {
    public float speed = 50f;
    private Rigidbody _rb;
    bool nearInteractableObject = false;
    GameObject obj;

    // Use this for initialization
    void Start () {
        _rb = GetComponent<Rigidbody>();
	}

    private void Update()
    {
        if(Input.GetButtonDown("Fire1") && nearInteractableObject)
        {
            if (obj != null)
            {
                var a = obj.gameObject.GetComponent<tmp_Intractable>();
                a.IntractableObjectDescription();
            }
            else
                Debug.Log(" FUCK");
        }
        Debug.Log(nearInteractableObject);
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        _rb.AddForce(movement * speed);
	}

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Intractable")
        {
            Debug.Log(" Olen pöydän lähellä");
            obj = other.gameObject; //other.gameObject.GetComponent<tmp_Intractable>();  
        }
    }

    public bool TogglenearInteractableObject(bool toggle)
    {
        nearInteractableObject = toggle;
        return toggle;
    }

    public void Intractable(GameObject intractableObj)
    {
        obj = intractableObj;

    }
    public void RemoveIntractable()
    {
        obj = null;
    }
}