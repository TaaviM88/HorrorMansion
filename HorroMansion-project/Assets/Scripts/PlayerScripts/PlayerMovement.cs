using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed;
    public float rotationSpeed; 
    private Rigidbody rb;
    Transform target;
    bool enableMovement = true;
    Animator anime;
    // Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        anime = GetComponent<Animator>();
        
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        float rotateHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        /*Vector3 movement = new Vector3(0, 0, moveVertical);
        rb.AddForce(movement * moveSpeed);*/

        //Player moves forward
        if (moveVertical > 0)
        {
            rb.velocity = transform.forward * moveSpeed * moveVertical;
            /*anime.SetBool("isWalking", true);
            anime.SetBool("movesForward", true);*/
            
        }
        //Player moves backward
        else if (moveVertical < 0)
        {
            rb.velocity = transform.forward * moveSpeed * moveVertical / 2;
            anime.SetBool("isWalking", true);
            anime.SetBool("movesForward", false);
        }
        else
            anime.SetBool("isWalking", false);

        transform.Rotate(Vector3.up * rotationSpeed * rotateHorizontal * Time.deltaTime);
        anime.SetFloat("moveSpeed", moveVertical);
    }

    public void ToggleMovement(bool move)
    {
        enableMovement = move;
    }

   
}
