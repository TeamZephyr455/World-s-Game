using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMonsterCreation : MonoBehaviour {

	//public GameObject playerPrefab;
	public GameObject enemyPrefab;
	public GameObject monsterPrefab;

	// Use this for initialization
	void Start () {
		Vector3 enemyPos1 = transform.position;
		enemyPos1.x = 16;
		enemyPos1.y = 9;
		enemyPos1.z = 0;
		transform.position = enemyPos1;

		Vector3 enemyPos2 = transform.position;
		enemyPos2.x = 16;
		enemyPos2.y = 7;
		enemyPos2.z = 0;
		transform.position = enemyPos2;

		Vector3 enemyPos3 = transform.position;
		enemyPos3.x = 16;
		enemyPos3.y = 4;
		enemyPos3.z = 0;
		transform.position = enemyPos3;

		Vector3 monsterPos = transform.position;
		monsterPos.x = 16;
		monsterPos.y = 0;
		monsterPos.z = 0;

		Vector3 enemyPos4 = transform.position;
		transform.position = monsterPos;
		enemyPos4.x = 16;
		enemyPos4.y = -4;
		enemyPos4.z = 0;
		transform.position = enemyPos4;

		Vector3 enemyPos5 = transform.position;
		enemyPos5.x = 16;
		enemyPos5.y = -7;
		enemyPos5.z = 0;
		transform.position = enemyPos5;

		Vector3 enemyPos6 = transform.position;
		enemyPos6.x = 16;
		enemyPos6.y = -9;
		enemyPos6.z = 0;
		transform.position = enemyPos6;

		Vector3 playerPos = transform.position;
		playerPos.x = -16;
		playerPos.y = 0;
		playerPos.z = 0;
		transform.position = playerPos;

		//Instantiate (playerPrefab, playerPos, transform.rotation);
		Instantiate (enemyPrefab, enemyPos1, transform.rotation);
		Instantiate (enemyPrefab, enemyPos2, transform.rotation);
		Instantiate (enemyPrefab, enemyPos3, transform.rotation);
		Instantiate (enemyPrefab, enemyPos4, transform.rotation);
		Instantiate (enemyPrefab, enemyPos5, transform.rotation);
		Instantiate (enemyPrefab, enemyPos6, transform.rotation);
		Instantiate (monsterPrefab, monsterPos, transform.rotation);

		// for (int i = 0; i <11; i++) {
			
		// 	if (i == 10) {
		// 		Instantiate (monsterPrefab, pos, transform.rotation);
		// 		Debug.Log(i);
		// 	}
		// }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
