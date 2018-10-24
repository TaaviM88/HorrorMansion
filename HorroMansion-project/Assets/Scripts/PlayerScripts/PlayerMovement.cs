using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed;
    public float rotationSpeed; 
    private Rigidbody rb;
    

    // Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        float rotateHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        /*Vector3 movement = new Vector3(0, 0, moveVertical);
        rb.AddForce(movement * moveSpeed);*/

        if (moveVertical > 0)
        {

            rb.velocity = transform.forward * moveSpeed * moveVertical;
        }

        else if (moveVertical < 0)
        {
            rb.velocity = transform.forward * moveSpeed * moveVertical / 2;
        }

        transform.Rotate(Vector3.up * rotationSpeed * rotateHorizontal * Time.deltaTime);

        

         
   
    }
}
