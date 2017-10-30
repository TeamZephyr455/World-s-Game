using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField]
    private int startingHealth;

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
            Destroy(gameObject);
        }
    }
}
