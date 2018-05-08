using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_shop : MonoBehaviour {

    // Initialize the public variables
    public int price;
    public bool isPickaxeShop;
    public bool isHeadlightShop;
    public bool isSellShop;
    public bool isWoodShop;
    public GameObject player;
    public GameObject PlayerSpotlight;
    public TextMesh priceText;

    // Initialize the private variables
    private bool activated;
    private string interactKey;

    // Use this for initialization
    void Start ()
    {
        Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>());
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (player.GetComponent<scr_playerMovement>().keyboardControls)
            interactKey = "Interact Keyboard";
        else
            interactKey = "Interact Joy";

        if (Input.GetAxis(interactKey) <= 0)
            activated = false;

        priceText.text = "[PRICE] : " + price;
	}

    // Check for collision with the player
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "GridCursor" && Input.GetAxis(interactKey) > 0 && !activated && player.GetComponent<scr_playerStats>().coin >= price)
        {
            if (isPickaxeShop)
                player.GetComponent<scr_playerStats>().pickaxeLevel++;

            if (isHeadlightShop)
            {
                if (player.GetComponent<scr_playerStats>().sightLevel <= 0f)
                    PlayerSpotlight.SetActive(true);

                player.GetComponent<scr_playerStats>().sightLevel++;
            }

            if (isSellShop)
            {
                player.GetComponent<scr_playerStats>().coin += player.GetComponent<scr_playerStats>().coal * 2;
                player.GetComponent<scr_playerStats>().coal = 0;
            }

            if (isWoodShop)
                player.GetComponent<scr_playerStats>().wood += 5;

            player.GetComponent<scr_playerStats>().coin -= price;

            if (!isWoodShop)
                price *= 2;

            activated = true;
        }
    }
}
