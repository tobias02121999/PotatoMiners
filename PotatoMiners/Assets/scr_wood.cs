using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_wood : MonoBehaviour {

    // Initialize the private variables
    private GameObject player;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<scr_placeWood>().placedWood.Add(this.gameObject);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
