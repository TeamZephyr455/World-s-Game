﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour {
	
	public int health;
	public float invulPeriod = 0;
	float invulnTimer = 0;
	int correctLayer;

	void Start() {
		correctLayer = gameObject.layer;
	}
		

	void OnTriggerEnter2D() {
		Debug.Log ("Trigger");
		health--;
		invulnTimer = invulPeriod;
		gameObject.layer = 10;
	}

	void Update() {

		invulnTimer -= Time.deltaTime;

		if (invulnTimer <=0) {
			gameObject.layer = correctLayer;
		}

		if (health <= 0) {
			Die ();
		}
	}
	void Die() {
		Destroy(gameObject);
	}
}
