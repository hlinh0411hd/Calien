using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberEnemy : AEnemy
{
    private Vector2 dir;
    private Vector2 colliderPosition;

    protected override void OnDead()
    {
        Destroy(gameObject);
    }

    protected override void ChangePosition()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            if (target != null)
            {
                Vector2 shipPos = target.transform.position;
                float dx = shipPos.x - transform.position.x;
                float dy = shipPos.y - transform.position.y;
                float dis = Mathf.Sqrt(dx * dx + dy * dy);
                if (dis <= 0) return;

                Vector2 position = transform.position;
                position.x += dx * (1 / dis) * speed * Time.deltaTime;
                position.y += dy * (1 / dis) * speed * Time.deltaTime;

                transform.position = position;
            }
            else
            {
                Vector2 position = transform.position;
                position.x += speed * Time.deltaTime;
                position.y += speed * Time.deltaTime;

                transform.position = position;
            }
        }
        if (gameObject.CompareTag("Obstacle"))
        {
            float difX = -colliderPosition.x + transform.position.x;
            float difY = -colliderPosition.y + transform.position.y;
            float x = difX == 0 ? 0 : difX / Mathf.Max(Mathf.Abs(difX), Mathf.Abs(difY));
            float y = difY == 0 ? 0 : difY / Mathf.Max(Mathf.Abs(difX), Mathf.Abs(difY));
            dir = new Vector2(x, y);
            rb.velocity = dir * 3;
        }
    }

    protected override void Fire()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    new void OnTriggerEnter2D(Collider2D other)
    {
        GameObject objectCollider = other.gameObject;
        Damage damage = objectCollider.GetComponent<Damage>();
        switch (objectCollider.tag)
        {
            case "Player":
                AFunc aFunc = objectCollider.GetComponent<AFunc>();
                if (aFunc != null)
                {
                    switch (aFunc.id)
                    {
                        case FuncController.SHEILD:
                            colliderPosition = objectCollider.transform.parent.transform.position;
                            ShieldController shieldController = (ShieldController)aFunc;
                            if (shieldController.currentTimePush > 0)
                            {
                                SetUpObstacle();
                                StartCoroutine(IEnDestroyInTime(1, damage.damage));
                                transform.rotation = objectCollider.transform.rotation;
                            } else
                            {
                                OnDamage(damage.damage);
                            }
                            break;
                    }
                }
                else
                {
                    OnDamage(damage.damage);
                }
                break;
            case "Obstacle":
                OnDamage(damage.damage);
                break;
            case "Enemy":
                if (gameObject.CompareTag("Obstacle"))
                {
                    OnDamage(damage.damage);
                }
                break;
        }

    }

    private void SetUpObstacle()
    {
        gameObject.tag = "Obstacle";
    }

    private IEnumerator IEnDestroyInTime(float time, float damage)
    {
        yield return new WaitForSeconds(time);

        OnDamage(damage);
    }
}
