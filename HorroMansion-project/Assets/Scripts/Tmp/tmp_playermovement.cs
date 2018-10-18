using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tmp_playermovement : MonoBehaviour {
    public float speed = 50f;
    private Rigidbody _rb;
	// Use this for initialization
	void Start () {
        _rb = GetComponent<Rigidbody>();
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
        if(other.gameObject.tag == "Intractable")
        {
            
        }
    }
}
