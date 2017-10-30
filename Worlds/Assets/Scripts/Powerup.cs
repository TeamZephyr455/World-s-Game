using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

    [SerializeField]
    private bool isBombAmmo;
    [SerializeField]
    private int bombsToAdd;

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


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Physics2D.IgnoreCollision(collision, GetComponent<Collider2D>());
        }

        if (collision.name == "Player")
        {
            if (isWeaponPickup)
            {
                thePlayer.swapWeapon(weapon);
            }

            if(isBombAmmo)
            {
                thePlayer.bombCount += bombsToAdd;
            }
            
            gameObject.SetActive(false);
        }

    }
}
