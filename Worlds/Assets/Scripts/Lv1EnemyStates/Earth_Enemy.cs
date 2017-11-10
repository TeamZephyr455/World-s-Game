using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth_Enemy : Character_Lv1
{

    private IEnemyState currentState;

    public GameObject Target { get; set; }

    [SerializeField]
    private float shootRange;

    // Use this for initialization
    public override void Start()
    {
        base.Start();
        ChangeState(new IdleState());
    }

    private void LookAtTarget()
    {
        if(Target != null)
        {
            float xDir = Target.transform.position.x - transform.position.x;

            if (xDir < 0 && faceright || xDir > 0 && !faceright)
            {
                ChangeDirection();
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (!IsDead)
        {
            currentState.Execute();
            LookAtTarget();
        }
        else
        {
            Destroy(gameObject);
        }
     
    }

    public void ChangeState(IEnemyState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;

        currentState.Enter(this);
    }

    public void Move()
    {
        if (!Attack)
        {
            myAnimator.SetFloat("Speed", 1);

            transform.Translate(GetDirection() * (movespeed * Time.deltaTime));
        }

    }

    public Vector2 GetDirection()
    {
        return faceright ? Vector2.right : Vector2.left;
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        currentState.OnTriggerEnter(other);
    }

    public override IEnumerator TakeDamage()
    {
        Health -= 10;

        if (!IsDead)
        {

        }
        else
        {
            yield return null;
        }
    }

    public override bool IsDead
    {
        get
        {
            return Health <= 0;
        }
    }
}
