using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMonsterCreation : MonoBehaviour {

	//public GameObject playerPrefab;
	public GameObject enemyPrefab1;
	public GameObject enemyPrefab2;
	public GameObject enemyPrefab3;
	public GameObject enemyPrefab4;
	public GameObject monsterPrefab;

	// Use this for initialization
	void Start () {
		Vector3 enemyPos1 = transform.position;
		enemyPos1.x = 6;
		enemyPos1.y = 9;
		enemyPos1.z = 0;
		transform.position = enemyPos1;

		Vector3 enemyPos2 = transform.position;
		enemyPos2.x = 17;
		enemyPos2.y = 7;
		enemyPos2.z = 0;
		transform.position = enemyPos2;

		Vector3 enemyPos3 = transform.position;
		enemyPos3.x = 26;
		enemyPos3.y = 4;
		enemyPos3.z = 0;
		transform.position = enemyPos3;

		Vector3 monsterPos = transform.position;
		monsterPos.x = 40;
		monsterPos.y = 0;
		monsterPos.z = 0;

		Vector3 enemyPos4 = transform.position;
		transform.position = monsterPos;
		enemyPos4.x = 34;
		enemyPos4.y = -4;
		enemyPos4.z = 0;
		transform.position = enemyPos4;

		Vector3 playerPos = transform.position;
		playerPos.x = -13;
		playerPos.y = 0;
		playerPos.z = 0;
		transform.position = playerPos;

		//Instantiate (playerPrefab, playerPos, transform.rotation);
		Instantiate (enemyPrefab1, enemyPos1, transform.rotation);
		Instantiate (enemyPrefab2, enemyPos2, transform.rotation);
		Instantiate (enemyPrefab3, enemyPos3, transform.rotation);
		Instantiate (enemyPrefab4, enemyPos4, transform.rotation);
		Instantiate (monsterPrefab, monsterPos, transform.rotation);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
