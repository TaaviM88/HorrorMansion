using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Vector3 _axis;

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        _axis = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        _forward = _axis.y * 
		
	}
}
