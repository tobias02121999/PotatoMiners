using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_blockVisibility : MonoBehaviour {

    // Initialize the public variables  
    public MeshRenderer blockMeshRenderer;
    public GameObject gameController;

    // Initialize the private variables
    private GameObject player;
    private float distanceToWood;
    private float woodSightLevel;
    private bool inPlayerVision;
    private bool inWoodVision;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        woodSightLevel = gameController.GetComponent<scr_gameSettings>().woodSightLevel;
	}

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= player.GetComponent<scr_playerStats>().sightLevel * 6)
            inPlayerVision = true;
        else
            inPlayerVision = false;

        for (int i = 0; i <= player.GetComponent<scr_placeWood>().placedWood.Count - 1; i++)
        {
            distanceToWood = Vector3.Distance(transform.position, player.GetComponent<scr_placeWood>().placedWood[i].transform.position);
            if (distanceToWood <= woodSightLevel * 6)
            {
                inWoodVision = true;
                i = player.GetComponent<scr_placeWood>().placedWood.Count;
            }
            else
                inWoodVision = false;
        }

        if (inPlayerVision || inWoodVision)
            blockMeshRenderer.enabled = true;
        else
            blockMeshRenderer.enabled = false;         
	}
}
