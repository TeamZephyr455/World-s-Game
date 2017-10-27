using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bomb : MonoBehaviour
{

    [SerializeField]
    private float horizontalPower = 10000;
    [SerializeField]
    private float verticalPower = 10000;

    [SerializeField]
    public int ammo;

    [SerializeField]
    private LayerMask whatToColliideWith;
    public bool collided = false;
    public float collisionRadius = 0.4f;

    public Rigidbody2D myRigidbody;

    private Vector2 direction;

    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        
    }

    public void Initialize(Vector2 direction)
    {
        GetComponent<Rigidbody2D>().AddForce(direction * horizontalPower);
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * verticalPower);
    }
}
