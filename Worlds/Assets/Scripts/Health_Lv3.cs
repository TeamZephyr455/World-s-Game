using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Lv3 : MonoBehaviour {

    [SerializeField]
    private int startingHealth;
    [SerializeField]
    private bool isPlayer;

    private int currentHealth;

	// Use this for initialization
	void Start () {
        currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        IsDead();
    }

    private void IsDead()
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

        }
    }

    public void ResetHealth()
    {
        currentHealth = startingHealth;
    }
}
