﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet_Lv1 : MonoBehaviour {

    [SerializeField]
    private float speed;

    private Rigidbody2D myRigidbody;

    private Vector2 direction;

    [SerializeField]
    public float fireRate;
    [SerializeField]
    public int damage;
    [SerializeField]
    public float timeToFire;
    [SerializeField]
    public int ammo;

    //public LayerMask notToHit;

    // Use this for initialization
    void Start () {

        myRigidbody = GetComponent<Rigidbody2D>();

	}

    private void FixedUpdate()
    {
        myRigidbody.velocity = direction * speed;
    }

    public void Initialize(Vector2 direction)
    {
        this.direction = direction;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
        {
            Health_Lv1 enemyHealth = collision.gameObject.GetComponent<Health_Lv1>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
            Destroy(gameObject);
            return;
        }
    }
}
