using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_placeWood : MonoBehaviour {

    // Initialize the public variables
    public GameObject gridCursor;
    public GameObject wood;

    // Initialize the private variables
    private bool activated;
    private string interactKey;
    private GameObject obj;
    private GameObject player;
    public List<GameObject> placedWood = new List<GameObject>();

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
	}

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<scr_playerMovement>().keyboardControls)
            interactKey = "Interact Keyboard";
        else
            interactKey = "Interact Joy";

        if (!gridCursor.GetComponent<scr_gridCursor>().isColliding && Input.GetAxis(interactKey) > 0 && !activated && GetComponent<scr_playerStats>().wood >= 1)
        {
            obj = Instantiate(wood, gridCursor.transform) as GameObject;
            obj.transform.parent = null;

            GetComponent<scr_playerStats>().wood--;
            activated = true;
        }

        if (Input.GetAxis(interactKey) <= 0)
            activated = false;
    }
}
