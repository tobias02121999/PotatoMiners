using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_lava : MonoBehaviour {

    // Initialize the public variables
    public float spreadAlarmDuration;
    public GameObject lavaSpawner;

    // Initialize the private variables
    private float spreadAlarm;

	// Use this for initialization
	void Start ()
    {
        spreadAlarm = spreadAlarmDuration;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (spreadAlarm <= 0f)
        {
            Instantiate(lavaSpawner, transform.position + (transform.forward * 3.2f), transform.rotation);
            Instantiate(lavaSpawner, transform.position - (transform.forward * 3.2f), transform.rotation);
            Instantiate(lavaSpawner, transform.position + (transform.right * 3.2f), transform.rotation);
            Instantiate(lavaSpawner, transform.position - (transform.right * 3.2f), transform.rotation);

            spreadAlarm = spreadAlarmDuration;
        }

        spreadAlarm--;
	}
}
