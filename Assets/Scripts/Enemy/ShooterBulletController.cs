using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterBulletController : ABullet
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject go = collision.gameObject;
        if (go.CompareTag("Player"))
        {
            AFunc aFunc = go.GetComponent<AFunc>();
            if (aFunc != null)
            {
                switch (aFunc.id)
                {
                    case FuncController.SHEILD:
                        ShieldController shieldController = (ShieldController)aFunc;
                        if (shieldController.currentTimePush > 0)
                        {
                            SetDirRevert();
                            SetUpForPlayer();
                        } else
                        {
                            Destroy(gameObject);
                        }
                        break;
                }
            } else
            {
                Destroy(gameObject);
            }
        }
        if (go.CompareTag("Enemy"))
        {
            if (gameObject.CompareTag("Player"))
                Destroy(gameObject);
        }
        if (go.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }

    public void SetDirRevert()
    {
        transform.RotateAround(transform.position, Vector3.forward, 180f);
        dir *= -1;
    }

    protected override void Move()
    {
        rb.velocity = dir * speed;
    }

    void SetUpForPlayer()
    {
        gameObject.tag = "Player";
        GetComponent<Damage>().damage = 20;
    }
}
