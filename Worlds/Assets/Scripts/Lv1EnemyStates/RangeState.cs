using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeState : IEnemyState
{
    private Earth_Enemy enemy;

    private float shootTimer;
    private float shootCooldown;
    private bool canShoot;

    public void Enter(Earth_Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Execute()
    {
        if (enemy.Target != null)
        {
            enemy.Move();
        }
        else
        {
            enemy.ChangeState(new IdleState());
        }
    }

    public void Exit()
    {

    }

    public void OnTriggerEnter(Collider2D other)
    {

    }

    private void ShootFire()
    {
        shootTimer += Time.deltaTime;

        if (shootTimer >= shootCooldown)
        {
            canShoot = true;
            shootTimer = 0;
        }

        if (canShoot)
        {
            canShoot = false;
            enemy.myAnimator.SetTrigger("throw");
        }
    }
}
