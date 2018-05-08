using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_lavaSpawner : MonoBehaviour {

    // Initialize the public variables
    public GameObject lava;

    // Initialize the private variables
    private float spawnAlarm = 1f;
    private GameObject obj;
    private GameObject player;
    private GameObject gridCursor;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gridCursor = GameObject.FindGameObjectWithTag("GridCursor");

        Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>());
        Physics.IgnoreCollision(gridCursor.GetComponent<Collider>(), GetComponent<Collider>());
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (spawnAlarm <= 0)
        {
            obj = Instantiate(lava, transform);
            obj.transform.parent = null;
            Destroy(this.gameObject);
        }

        spawnAlarm--;
	}

    // Check if colliding in general
    void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}
