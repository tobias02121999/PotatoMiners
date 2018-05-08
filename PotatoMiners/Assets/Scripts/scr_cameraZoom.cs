using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_cameraZoom : MonoBehaviour {

    // Initialize the public variables
    public GameObject player;
    public float zoom;
    public float zoomSpeed;

    // Initialize the private variables
    private string zoomAxis;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (player.GetComponent<scr_playerMovement>().keyboardControls)
            zoomAxis = "Mousewheel";
        else
            zoomAxis = "Vertical Joy 2";

        transform.position = player.transform.position + (transform.forward * zoom);
        zoom += Input.GetAxis(zoomAxis) * zoomSpeed;
	}
}
