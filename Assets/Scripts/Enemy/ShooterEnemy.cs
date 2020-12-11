using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : AEnemy
{
    private bool isMove = true;

    public float distanceToPlayer;

    public GameObject bullet;
    public Transform shooterTransform;

    public float timeSuicide;
    public float runSpeed;


    protected override void OnDead()
    {
        Destroy(gameObject);
    }

    protected override void ChangePosition()
    {
        if (target != null)
        {

            if (timeSuicide >= 0)
            {
                if (Vector2.Distance(target.transform.position, transform.position) < distanceToPlayer)
                {
                    isMove = false;
                }
                else isMove = true;
            } else
            {
                isMove = true;
                speed = runSpeed;
            }


            Vector2 relativePos = target.transform.position - transform.position;
            float angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;


            if (isMove)
            {
                rb.velocity = transform.up * speed;
            } else
            {
                rb.velocity = new Vector3(0, 0, 0);
            }
        }
        else
        {
            rb.velocity = transform.up * speed;
        }
    }

    protected override void Fire()
    {

        GameObject clone = Instantiate(bullet, shooterTransform.position, shooterTransform.rotation);
    }

    new void FixedUpdate()
    {
        base.FixedUpdate();
        timeSuicide -= Time.deltaTime;
    }

    new void Start()
    {
        base.Start();
        distanceToPlayer *= (Random.Range(0.3f, 1.5f));
        timeSuicide = 5 + Random.Range(0f, 5f);
    }
}
