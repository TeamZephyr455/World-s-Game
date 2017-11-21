using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMonsterCreation : MonoBehaviour {

	// public GameObject playerPrefab;
	public GameObject enemyPrefab1;
	public GameObject enemyPrefab2;
	public GameObject enemyPrefab3;
	public GameObject enemyPrefab4;
	public GameObject enemyPrefab5;
	public GameObject monsterPrefab;

	// Use this for initialization
	void Start () {

		Vector3 enemyPos1 = transform.position;
		enemyPos1.x = 27;
		enemyPos1.y = 9;
		enemyPos1.z = 0;
		transform.position = enemyPos1;

		Vector3 enemyPos2 = transform.position;
		enemyPos2.x = 20;
		enemyPos2.y = 5;
		enemyPos2.z = 0;
		transform.position = enemyPos2;

		Vector3 enemyPos3 = transform.position;
		enemyPos3.x = 25;
		enemyPos3.y = 2;
		enemyPos3.z = 0;
		transform.position = enemyPos3;

		Vector3 monsterPos = transform.position;
		monsterPos.x = 33;
		monsterPos.y = -1;
		monsterPos.z = 0;
		transform.position = monsterPos;

		Vector3 enemyPos4 = transform.position;
		enemyPos4.x = 23;
		enemyPos4.y = -6;
		enemyPos4.z = 0;
		transform.position = enemyPos4;

		Vector3 enemyPos5 = transform.position;
		enemyPos5.x = 28;
		enemyPos5.y = -10;
		enemyPos5.z = 0;
		transform.position = enemyPos5;

		Vector3 playerPos = transform.position;
		playerPos.x = -18;
		playerPos.y = 0;
		playerPos.z = 0;
		transform.position = playerPos;

		// Instantiate (playerPrefab, playerPos, transform.rotation);
		Instantiate (enemyPrefab1, enemyPos1, transform.rotation);
		Instantiate (enemyPrefab2, enemyPos2, transform.rotation);
		Instantiate (enemyPrefab3, enemyPos3, transform.rotation);
		Instantiate (enemyPrefab4, enemyPos4, transform.rotation);
		Instantiate (enemyPrefab5, enemyPos5, transform.rotation);
		Instantiate (monsterPrefab, monsterPos, transform.rotation);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
