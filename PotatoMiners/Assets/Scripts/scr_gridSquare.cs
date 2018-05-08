using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_gridSquare : MonoBehaviour {

    // Initialize the public variables
    public Transform gridCursorTransform;
    public GameObject[] blocks;

	// Use this for initialization
	void Start ()
    {
        int blockType = Mathf.RoundToInt(Random.Range(0f, blocks.Length - 1f));
        Instantiate(blocks[blockType], transform);
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    // Check for collision with the player
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && !other.gameObject.GetComponent<scr_playerMovement>().isSelected)
        {
            gridCursorTransform.position = transform.position;
            other.gameObject.GetComponent<scr_playerMovement>().isSelected = true;
        }
    }

    // Check if the player leaves the trigger collision
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && other.gameObject.GetComponent<scr_playerMovement>().isSelected)
            other.gameObject.GetComponent<scr_playerMovement>().isSelected = false;
    }
}
