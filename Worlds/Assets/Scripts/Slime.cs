using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour {

    private Rigidbody2D enemyRigidBody;

    [SerializeField]
    private float speed;

    [SerializeField]
    private bool facingRight;

    [SerializeField]
    public int StartingHealth;

    public int health;

    // Use this for initialization
    void Start ()
    {
        enemyRigidBody = GetComponent<Rigidbody2D>();
        health = StartingHealth;
	}
	
	// Update is called once per frame
	void Update ()
    {
        enemyRigidBody.velocity = new Vector2(-speed, enemyRigidBody.velocity.y);

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Walls")
        {
            Flip();
        }

        if (collision.tag == "Bullet")
        {
            Bullet enemyBullet = collision.GetComponent<Bullet>();
            if (enemyBullet != null)
            {
                health -= enemyBullet.damage; 
            }
        }

    }

    private void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;

        theScale.x *= -1;

        transform.localScale = theScale;

        speed *= -1;
    }

    private void IsDead()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
