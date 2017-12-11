using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour {
	public int health;

	void OnTriggerEnter2D() {
		health--;
	}

	void Update() {
		if (health <= 0) 
			Destroy(gameObject);
	}
}
