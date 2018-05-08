using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_playerMovement : MonoBehaviour {

    // Initialize the public variables
    public Rigidbody playerRigidbody;
    public float movementSpeed;
    public float sprintSpeed;
    public float slowdownSpeed;
    public float animationSpeed;
    public bool keyboardControls;
    public Transform playerModelTransform;

    [HideInInspector]
    public bool isMoving;

    [HideInInspector]
    public bool isSelected;

    // Initialize the private variables
    private float currentMovementSpeed;
    private float playerModelRotationX;
    private string movementAxisHorizontal;
    private string movementAxisVertical;
    private string sprintKey;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Check if the player is using a keyboard or gamepad
        if (keyboardControls)
        {
            movementAxisHorizontal = "Horizontal Keyboard";
            movementAxisVertical = "Vertical Keyboard";
            sprintKey = "Sprint Keyboard";
        } else
        {
            movementAxisHorizontal = "Horizontal Joy 1";
            movementAxisVertical = "Vertical Joy 1";
            sprintKey = "Sprint Joy";
        }

        // Check if the player is attempting to move
        if (Input.GetAxis(movementAxisHorizontal) != 0 || Input.GetAxis(movementAxisVertical) != 0)
            isMoving = true;
        else
            isMoving = false;

        // Calculate the current angle of the joystick axis used for movement
        float angle = Mathf.Atan2(Input.GetAxis(movementAxisHorizontal), Input.GetAxis(movementAxisVertical)) * Mathf.Rad2Deg;

        // Apply the calculated angle to the current Y rotation of the player if he is moving
        if (isMoving)
        {
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, angle, transform.eulerAngles.z);

            if (Input.GetAxis(sprintKey) > 0)
                currentMovementSpeed = sprintSpeed;
            else
                currentMovementSpeed = movementSpeed;
        }
        else
        {
            if (currentMovementSpeed >= slowdownSpeed)
                currentMovementSpeed -= slowdownSpeed;
            else
                currentMovementSpeed = 0f;
        }
    }

    void FixedUpdate()
    {
        // Move the player forward with his current speed
        playerRigidbody.velocity = transform.forward * currentMovementSpeed;

        // Animate the player model
        playerModelTransform.Rotate(currentMovementSpeed * animationSpeed, 0f, 0f);
    }
}
