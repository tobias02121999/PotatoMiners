using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_gridDanger : MonoBehaviour {

    // Initialize the public variables
    public GameObject gameController;
    public GameObject rubble;

    // Initialize the private variables
    private float rubbleSpawnTimer;
    private GameObject obj;

	// Use this for initialization
	void Start ()
    {
        rubbleSpawnTimer = Random.Range(gameController.GetComponent<scr_gameSettings>().rubbleSpawnTimerMin, gameController.GetComponent<scr_gameSettings>().rubbleSpawnTimerMax);
    }
	
	// Update is called once per frame
	void Update ()
    {
        rubbleSpawnTimer--;

        if (rubbleSpawnTimer <= 0)
        {
            obj = Instantiate(rubble, transform);
            obj.transform.parent = null;
            Destroy(this.gameObject);
        }
    }

    // Check for collision with wooden supports
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Wood")
            Destroy(this.gameObject);
    }
}
