using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_gridCursor : MonoBehaviour {

    // Initialize the public variables
    public GameObject player;
    
    [HideInInspector]
    public bool isColliding;

	// Use this for initialization
	void Start ()
    {
        Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>());
    }
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    // Check for collision in general
    void OnCollisionStay(Collision collision)
    {
        isColliding = true;
    }

    void OnTriggerStay(Collider other)
    {
        isColliding = true;
    }

    // Check for collision exit in general
    void OnCollisionExit(Collision collision)
    {
        isColliding = false;
    }

    void OnTriggerExit(Collider other)
    {
        isColliding = false;
    }
}
