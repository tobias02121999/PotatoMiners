using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_playerStats : MonoBehaviour {

    // Initialize the public variables
    public int sightLevel;
    public int pickaxeLevel;
    public int coin;
    public int wood;
    public int coal;
    public Text textCoin;
    public Text textWood;
    public Text textCoal;
    public Text textPickaxe;
    public Text textHeadlight;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        textCoin.text = "[COIN] : " + coin;
        textWood.text = "[WOOD] : " + wood;
        textCoal.text = "[COAL] : " + coal;
        textPickaxe.text = "[PICKAXE LVL] : " + pickaxeLevel;
        textHeadlight.text = "[HEADLIGHT LVL] : " + sightLevel;
    }
}
