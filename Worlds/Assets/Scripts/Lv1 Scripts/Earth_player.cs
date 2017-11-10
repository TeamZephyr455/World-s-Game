using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth_player : Character_Lv1
{
    private Rigidbody2D myRigidBody;

    [SerializeField]
    private Transform[] groundPoints;

    [SerializeField]
    private float groundRadius;

    [SerializeField]
    private LayerMask whatIsGround;

    private bool isGrounded;

    private bool Jump;

    [SerializeField]
    private float JumpPower;

    private Vector2 startPos;

    public override bool IsDead
    {
        get
        {
            return Health <= 0;
        }
    }

    // Use this for initialization
    public override void Start()
    {
        startPos = transform.position;
        base.Start();
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleInput();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        isGrounded = IsGrounded();

        HandleMovement(horizontal);

        Flip(horizontal);

        ResetValues();
    }

    private void HandleMovement(float horizontal)
    {
        myRigidBody.velocity = new Vector2(horizontal * movespeed, myRigidBody.velocity.y); //Moves Player left x=-1 y=0 exactly.

        myAnimator.SetFloat("Speed", Mathf.Abs(horizontal));

        if (isGrounded && Jump)
        {
            isGrounded = false;
            myRigidBody.AddForce(new Vector2(0, JumpPower));
        }

    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Jump = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootFire(0);
        }
    }

    private void Flip(float horizontal)
    {
        if (horizontal > 0 && !faceright || horizontal < 0 && faceright)
        {
            ChangeDirection();
        }
    }

    private void ResetValues()
    {
        Jump = false;
    }

    private bool IsGrounded()
    {
        if (myRigidBody.velocity.y <= 0)
        {
            foreach (Transform point in groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);

                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public override void ShootFire(int value)
    {

        base.ShootFire(value);

    }

 /*   private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Hero")
        {

        }
   }*/

    public override IEnumerator TakeDamage()
    
    {
        Health -= 10;

        if (IsDead)
        {
            yield return null;
        }
    }
}
