using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {
	[SerializeField]
	private Stat healthStat;
	public float invulPeriod = 0;
	float invulnTimer = 0;
	int correctLayer;
	
	// public GameObject playerPrefab;
	Vector3 pos = new  Vector3(-18,0,0);
	Vector3 endPos = new  Vector3(-18,-100,0);

	public int numLives;
	float respawnTimwer = 1;

	private void Awake() {
		healthStat.Initialize();
	}

	void OnTriggerEnter2D() {
		Debug.Log ("Trigger");
		healthStat.CurrentVal -=10;
		invulnTimer = invulPeriod;
		gameObject.layer = 10;
	}

	void Update () {
		invulnTimer -= Time.deltaTime;
		if (invulnTimer <=0)
			gameObject.layer = correctLayer;
		respawnTimwer -= Time.deltaTime;
		if (healthStat.CurrentVal <= 0) {
			Die ();
			numLives--;
		}
		Death();
	}

	void Death() {
		if (numLives == 0) {
			healthStat.CurrentVal = 0;
			transform.position = endPos;
			// Destroy(gameObject);
		}
	}

	void Die() {
		//Destroy(gameObject);
		if (numLives > 0) {
			transform.position = pos;
			healthStat.CurrentVal = 10;
		}
		// else {
		// 	Destroy(gameObject);
		// 	healthStat.CurrentVal = 0;
		// }

	}
	void OnGUI() {
		if (numLives > 0)
			GUI.Label (new Rect (500, 100, 500, 500), "Lives left: " + numLives);
		else
			GUI.Label (new Rect (Screen.width/2 - 50, Screen.height/2 - 25, 200, 100), "Game Over");
	}
}

