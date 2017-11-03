using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime_Lv3 : MonoBehaviour {

    private Rigidbody2D enemyRigidBody;

    [SerializeField]
    private float speed;

    [SerializeField]
    private bool facingRight;

    [SerializeField]
    private int damage;

    [SerializeField]
    private int bumpForce;

    // Use this for initialization
    void Start ()
    {
        enemyRigidBody = GetComponent<Rigidbody2D>();
        if (facingRight)
            Flip();
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

        if (collision.tag == "Player")
        {
            Health_Lv3 playerHealth = collision.gameObject.GetComponent<Health_Lv3>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                collision.GetComponent<Player_Lv3>().KnockBack();
                collision.GetComponent<Rigidbody2D>().AddForce(Vector2.left);
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

    public void Initialize(bool goRight)
    {
        facingRight = goRight;
    }
}
