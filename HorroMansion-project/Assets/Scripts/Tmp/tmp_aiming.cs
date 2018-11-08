using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tmp_aiming : MonoBehaviour {

    //public bool ifAiming = false;

    public GameObject FindClosestEnemy()
    {
        GameObject[] _gameObjects;

        _gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject _gameObject in _gameObjects)
        {
            Vector3 diff = _gameObject.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = _gameObject;
                distance = curDistance;
                Debug.DrawLine(this.transform.position, closest.transform.position);
            }
        }
        return closest;
        

    }
    
    
    
    
    
    
    
    //public Transform target; 


	// Use this for initialization
	/*void Start () {

        
		        
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
        }*/
		
	}

