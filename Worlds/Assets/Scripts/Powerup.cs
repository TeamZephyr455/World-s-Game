using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

    [SerializeField]
    private bool isWeaponPickup;
    [SerializeField]
    private GameObject weapon;

    private Player thePlayer;

	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<Player>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            if (isWeaponPickup)
            {
                thePlayer.swapWeapon(weapon);
            }
            
            gameObject.SetActive(false);
        }

    }
}
