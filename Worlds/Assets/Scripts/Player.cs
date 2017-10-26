﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Rigidbody2D myRigidbody;

    private Animator myAnimator;

    [SerializeField]
    private float movementSpeed;

    private bool facingRight;

    [SerializeField]
    private Transform[] groundPoints;

    [SerializeField]
    private float groundRadius;

    [SerializeField]
    private LayerMask whatIsGround;

    private bool isGrounded;

    private bool jump;

    [SerializeField]
    private bool airControl;

    [SerializeField]
    private float jumpForce;

    private GameObject weaponPrefab;

    [SerializeField]
    private GameObject pistolPrefab;

    [SerializeField]
    private GameObject machineGunPrefab;

    private float fireRate;
    private float Damage;
    private float timeToFire;
    private int ammoCount;

    // Use this for initialization
    void Start ()
    {
        facingRight = true;
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        swapWeapon(machineGunPrefab);

    }

    void Update()
    {
        HandleInput();
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        float horizontal = Input.GetAxis("Horizontal");

        isGrounded = isGroundedFcn();

        HandleMovement(horizontal);

        Flip(horizontal);

        ResetValues();
	}

    private void HandleMovement(float horizonatal)
    {
        if (isGrounded || airControl)
        {
            myRigidbody.velocity = new Vector2(horizonatal * movementSpeed, myRigidbody.velocity.y);
        }

        if(isGrounded && jump)
        {
            isGrounded = false;
            myRigidbody.AddForce(new Vector2(0, jumpForce));
        }



        myAnimator.SetFloat("speed", Mathf.Abs(horizonatal));
    }

    private void HandleInput()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (fireRate == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                ShootBullet();
            }
        }
        else
        {
            if (Input.GetButton("Fire1") && Time.time > timeToFire && ammoCount > 0)
            {
                timeToFire = Time.time + 1/fireRate;
                ShootBullet();
            }
        }

    }

    private void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;

            Vector3 theScale = transform.localScale;

            theScale.x *= -1;

            transform.localScale = theScale;
        }
    }

    private void ResetValues()
    {
        jump = false;
    }

    private bool isGroundedFcn()
    {
        if (myRigidbody.velocity.y <=0)
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

    public void ShootBullet()
    {
        //btns up + right
        if (Input.GetAxis("Vertical") > 0 && Input.GetAxis("Horizontal") > 0)
        {
            GameObject tmp = Instantiate(weaponPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 45)));
            tmp.GetComponent<Bullet>().Initialize(Vector2.up + Vector2.right);
        }

        //btns up + left
        else if (Input.GetAxis("Vertical") > 0 && Input.GetAxis("Horizontal") < 0)
        {
            GameObject tmp = Instantiate(weaponPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 135)));
            tmp.GetComponent<Bullet>().Initialize(Vector2.up + Vector2.left);
        }

        //btn up
        else if (Input.GetAxis("Vertical") > 0)
        {
            GameObject tmp = Instantiate(weaponPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 90)));
            tmp.GetComponent<Bullet>().Initialize(Vector2.up);
        }

        //btns down + right + !grounded
        else if (Input.GetAxis("Vertical") < 0 && Input.GetAxis("Horizontal") > 0 && !isGrounded)
        {
            GameObject tmp = Instantiate(weaponPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, -45)));
            tmp.GetComponent<Bullet>().Initialize(Vector2.down + Vector2.right);
        }

        //btns down + left + !grounded
        else if (Input.GetAxis("Vertical") < 0 && Input.GetAxis("Horizontal") < 0 && !isGrounded)
        {
            GameObject tmp = Instantiate(weaponPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, -135)));
            tmp.GetComponent<Bullet>().Initialize(Vector2.down + Vector2.left);
        }

        //btn down + !grounded
        else if (Input.GetAxis("Vertical") < 0 && !isGrounded)
        {
            GameObject tmp = Instantiate(weaponPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, -90)));
            tmp.GetComponent<Bullet>().Initialize(Vector2.down);
        }

        else if (facingRight)
        {
            GameObject tmp = Instantiate(weaponPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            tmp.GetComponent<Bullet>().Initialize(Vector2.right);
        }

        //facing left
        else
        {
            GameObject tmp = Instantiate(weaponPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            tmp.GetComponent<Bullet>().Initialize(Vector2.left);
        }

        if (ammoCount > 0)
        {
            ammoCount -= 1;
            if (ammoCount == 0)
            {
                swapWeapon(pistolPrefab);
            }
        }

    }

    public void swapWeapon(GameObject weapon)
    {
        weaponPrefab = weapon;
        fireRate = weaponPrefab.GetComponent<Bullet>().fireRate;
        Damage = weaponPrefab.GetComponent<Bullet>().damage;
        timeToFire = weaponPrefab.GetComponent<Bullet>().timeToFire;
        ammoCount = weaponPrefab.GetComponent<Bullet>().ammo;
}

}
