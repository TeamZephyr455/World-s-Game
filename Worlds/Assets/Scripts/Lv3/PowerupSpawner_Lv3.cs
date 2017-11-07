﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner_Lv3 : MonoBehaviour {

    [SerializeField]
    private GameObject powerupType;

    [SerializeField]
    private bool spawnOnStart;

    [SerializeField]
    private int numberToSpawn;

    [SerializeField]
    private float timeBetweenSpawn;

    private float spawnCountdown;

    // Use this for initialization
    void Start()
    {
        if (spawnOnStart)
            SpawnEnemy();
        spawnCountdown = timeBetweenSpawn;
    }

    // Update is called once per frame
    void Update()
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
        if (numberToSpawn == 0)
        {
            Destroy(gameObject);
        }
        else
        {
            GameObject tmp = Instantiate(powerupType, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            tmp.GetComponent<Powerup_Lv3>().Initialize();
            numberToSpawn -= 1;
        }
    }
}