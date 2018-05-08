using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_cameraMovement : MonoBehaviour {

    // Initialize the public variables
    public Transform playerTransform;
    public float followPercentageDivider;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        float distance = Vector3.Distance(transform.position, playerTransform.position) / followPercentageDivider;
        transform.position = Vector3.Lerp(transform.position, playerTransform.position, Mathf.Clamp(distance, 0f, 1f));
	}
}
