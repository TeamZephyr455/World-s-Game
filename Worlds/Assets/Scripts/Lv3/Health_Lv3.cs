using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Lv3 : MonoBehaviour {

    [SerializeField]
    private int startingHealth;
    [SerializeField]
    private bool isPlayer;
    [SerializeField]
    private float invulnerabilityTime;

    private bool invincible;

    private int currentHealth;

	// Use this for initialization
	void Start ()
    {
        currentHealth = startingHealth;
        invincible = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void TakeDamage(int damage)
    {
        if (!invincible)
        {
            currentHealth -= damage;
            if (!IsDead() && isPlayer)
            {
                invincible = true;
                Invoke("resetInvulnerablility", invulnerabilityTime);

            }
        }

    }

    private bool IsDead()
    {
        if (currentHealth <= 0)
        {
            if (isPlayer)
            {
                gameObject.GetComponent<Player_Lv3>().Death();
            }
            else
            {
                Destroy(gameObject);
            }
            return true;
        }
        else
            return false;
    }

    public void ResetHealth()
    {
        currentHealth = startingHealth;
    }

    private void resetInvulnerablility()
    {
        invincible = false;
    }
}
