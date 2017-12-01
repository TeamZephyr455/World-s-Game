using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {

	public GameObject playerPrefab;
	GameObject playerInstance = null;
	public int numLives;
	float respawnTimwer;

	void Start () {
		if (playerInstance == null)
			SpawnPlayer();
	}

	void SpawnPlayer() {
		numLives--;
		respawnTimwer = 1;
		if (numLives > 0)
			playerInstance = (GameObject)Instantiate (playerPrefab, transform.position, transform.rotation);
	}

	void Update () {
		if (playerInstance == null && numLives > 0) {
			respawnTimwer -= Time.deltaTime;
			if (respawnTimwer <= 0)
				SpawnPlayer ();
		}
	}

	void OnGUI() {
		if (numLives > 0 || playerInstance != null)
			GUI.Label (new Rect (500, 100, 500, 500), "Lives left: " + numLives);
		else 
			GUI.Label (new Rect (Screen.width/2 - 50, Screen.height/2 - 25, 200, 100), "Game Over");
	}
}
