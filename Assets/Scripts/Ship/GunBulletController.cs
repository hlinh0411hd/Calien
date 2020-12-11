using UnityEngine;
using System.Collections;

public class GunBulletController : ABullet {
    protected override void Move()
    {
        rb.velocity = dir * speed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject go = collision.gameObject;
        if (go.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
