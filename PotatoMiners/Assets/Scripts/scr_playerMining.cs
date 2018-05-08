using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_playerMining : MonoBehaviour {

    // Initialize the public variables
    public GameObject gridDanger;

    private GameObject obj;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    // Check for collision with mineable blocks
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<scr_mineable>().mineLevel <= GetComponent<scr_playerStats>().pickaxeLevel)
        {
            if (other.tag == "Coal")
                GetComponent<scr_playerStats>().coal++;

            obj = Instantiate(gridDanger, other.transform);
            obj.transform.parent = null;
            Destroy(other.gameObject);
        }
    }
}
