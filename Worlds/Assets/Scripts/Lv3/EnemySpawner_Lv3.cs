using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner_Lv3 : MonoBehaviour {

    [SerializeField]
    private GameObject enemyType1;

    [SerializeField]
    private bool spawnOnStart;

    [SerializeField]
    private int enemiesToSpawn;

    [SerializeField]
    private bool spawnFacingRight;

    [SerializeField]
    private float timeBetweenSpawn;

    private float spawnCountdown;

	// Use this for initialization
	void Start () {
        if (spawnOnStart)
            SpawnEnemy();
        spawnCountdown = timeBetweenSpawn;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (spawnCountdown <= 0)
        {
            SpawnEnemy();
            spawnCountdown = timeBetweenSpawn;
        }
        else spawnCountdown -= Time.deltaTime;
	}

    void SpawnEnemy()
    {
        if (enemiesToSpawn == 0)
        {
            Destroy(gameObject);
        }
        else
        {
            GameObject tmp = Instantiate(enemyType1, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            tmp.GetComponent<Slime_Lv3>().Initialize(spawnFacingRight);
            enemiesToSpawn -= 1;
        }
    }

}
