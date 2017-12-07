using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Lv3 : MonoBehaviour {

    [SerializeField]
    public int startingHealth;
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
        if (isPlayer)
        {
            GetComponent<Life_UI_Lv3>().UpdateMaxHealth(startingHealth);
            GetComponent<Life_UI_Lv3>().UpdateHealthBar(currentHealth);
        }
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
            if (isPlayer)
                GetComponent<Life_UI_Lv3>().UpdateHealthBar(currentHealth);
            if (!IsDead() && isPlayer)
            {
                invincible = true;
                gameObject.layer = LayerMask.NameToLayer("Invulnerable");
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
        GetComponent<Life_UI_Lv3>().UpdateHealthBar(currentHealth);
    }

    private void resetInvulnerablility()
    {
        if (isPlayer)
        {
            gameObject.layer = LayerMask.NameToLayer("Player");
        }
        invincible = false;
    }
}
