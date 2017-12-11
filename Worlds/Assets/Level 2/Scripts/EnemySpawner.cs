using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemyPrefab1;
	public GameObject enemyPrefab2;
	public GameObject enemyPrefab3;
	public GameObject enemyPrefab4;
	public GameObject enemyPrefab5;

	void Start () {
		Vector3 enemyPos1 = transform.position;
		enemyPos1.x = 22;
		enemyPos1.y = 9;
		enemyPos1.z = 0;
		transform.position = enemyPos1;

		Vector3 enemyPos2 = transform.position;
		enemyPos2.x = 18;
		enemyPos2.y = 5;
		enemyPos2.z = 0;
		transform.position = enemyPos2;

		Vector3 enemyPos3 = transform.position;
		enemyPos3.x = 28;
		enemyPos3.y = 2;
		enemyPos3.z = 0;
		transform.position = enemyPos3;

		Vector3 enemyPos4 = transform.position;
		enemyPos4.x = 23;
		enemyPos4.y = -6;
		enemyPos4.z = 0;
		transform.position = enemyPos4;

		Vector3 enemyPos5 = transform.position;
		enemyPos5.x = 25;
		enemyPos5.y = -10;
		enemyPos5.z = 0;
		transform.position = enemyPos5;

		Vector3 enemyPos6 = transform.position;
		enemyPos6.x = 16;
		enemyPos6.y = -4;
		enemyPos6.z = 0;
		transform.position = enemyPos6;

		Vector3 EnemyPos = transform.position;
		EnemyPos.x = 30;
		EnemyPos.y = -1;
		EnemyPos.z = 0;
		transform.position = EnemyPos;

		Instantiate (enemyPrefab1, enemyPos1, transform.rotation);
		Instantiate (enemyPrefab2, enemyPos2, transform.rotation);
		Instantiate (enemyPrefab3, enemyPos3, transform.rotation);
		Instantiate (enemyPrefab4, enemyPos4, transform.rotation);
		Instantiate (enemyPrefab5, enemyPos5, transform.rotation);
		Instantiate (enemyPrefab1, enemyPos6, transform.rotation);
	}
}
