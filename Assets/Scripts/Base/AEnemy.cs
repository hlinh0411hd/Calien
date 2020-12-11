using UnityEngine;
using System.Collections;

public abstract class AEnemy : MonoBehaviour {

    public GameObject target;
    public float speed;
    public float timeDelayFire;
    private float currentTimeDelayFire;
    protected Rigidbody2D rb;

    public Health health;

    protected void Start() {
        currentTimeDelayFire = timeDelayFire;
        rb = GetComponent<Rigidbody2D>();
    }

    protected void OnDamage(float h) {
        bool isDead = health.SubHealth(h);
        if (isDead)
        {
            OnDead();
        }
    }

    protected void FixedUpdate() {
        ChangePosition();

        currentTimeDelayFire -= Time.deltaTime;
        if (currentTimeDelayFire < 0) {
            Fire();
            currentTimeDelayFire = timeDelayFire;
        }
    }

    protected abstract void ChangePosition();
    protected abstract void Fire();
    protected abstract void OnDead();

    protected void OnTriggerEnter2D(Collider2D other)
    {
        GameObject objectCollider = other.gameObject;
        Damage damage = objectCollider.GetComponent<Damage>();
        switch (objectCollider.tag)
        {
            case "Player":
                OnDamage(damage.damage);
                break;
            case "Obstacle":
                OnDamage(damage.damage);
                break;
        }

    }
}
