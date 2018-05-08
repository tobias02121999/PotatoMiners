using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_levelMeshSwapper : MonoBehaviour {

    // Initialize the public variables
    public Mesh[] pickaxeLevelMesh;
    public GameObject player;
    public MeshFilter thisMeshFilter;
    public bool isPickaxe;
    public bool isHeadlight;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isPickaxe)
            thisMeshFilter.mesh = pickaxeLevelMesh[player.GetComponent<scr_playerStats>().pickaxeLevel];

        if (isHeadlight)
            thisMeshFilter.mesh = pickaxeLevelMesh[player.GetComponent<scr_playerStats>().sightLevel];
    }
}
