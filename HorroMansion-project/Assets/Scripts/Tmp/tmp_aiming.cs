using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tmp_aiming : MonoBehaviour {

    public bool ifAiming = false;
    public Transform target; 


	// Use this for initialization
	void Start () {

        
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Fire2"))
        {
            ifAiming = true;
            Vector3 targetposition = new Vector3(target.transform.position.x,
                                                    transform.position.y,
                                                    target.transform.position.z);
            transform.LookAt(targetposition);
            
        }

        if (Input.GetButtonUp("Fire2"))
        {
            ifAiming = false;   
        }
		
	}
}
