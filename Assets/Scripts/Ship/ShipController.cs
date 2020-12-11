using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public GameController gameController;
    public Health health;

    public float timeBeForced;

    // Start is called before the first frame update
    void Start()
    {
        timeBeForced = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBeForced > 0) timeBeForced -= Time.deltaTime;
    }

    void OnDamage(float h)
    {
        bool isDead = health.SubHealth(h);
        if (isDead)
        {
            Destroy(gameObject);
        }
    }

    public void AddHealth(float h)
    {
        health.AddHealth(h);
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        GameObject objectCollider = other.gameObject;
        if (objectCollider.tag == "Enemy")
        {
            Damage damage = objectCollider.GetComponent<Damage>();
            OnDamage(damage.damage);
        }
        if (objectCollider.tag == "Obstacle") {
            Damage damage = objectCollider.GetComponent<Damage>();
            float difX = transform.position.x - objectCollider.transform.position.x;
            float difY = transform.position.y - objectCollider.transform.position.y;
            float x = difX == 0 ? 0 : difX / Mathf.Max(Mathf.Abs(difX), Mathf.Abs(difY));
            float y = difY == 0 ? 0 : difY / Mathf.Max(Mathf.Abs(difX), Mathf.Abs(difY));
            Vector2 dir = new Vector2(x, y);
            for(int i = 0; i < transform.childCount; i++) {
                EngineController ec = transform.GetChild(i).GetComponent<EngineController>();
                if(ec != null) {
                    ec.dir = dir;
                    break;
                }
            }
            timeBeForced = 1f;
            OnDamage(damage.damage);
        }
    }


    protected void OnCollisionEnter2D(Collision2D other) {
        GameObject objectCollider = other.gameObject;
        if(objectCollider.tag == "Enemy") {
            Damage damage = objectCollider.GetComponent<Damage>();
            OnDamage(damage.damage);
        }
        if(objectCollider.tag == "Obstacle") {
            Damage damage = objectCollider.GetComponent<Damage>();
            float difX = transform.position.x - objectCollider.transform.position.x;
            float difY = transform.position.y - objectCollider.transform.position.y;
            float x = difX == 0 ? 0 : difX / Mathf.Max(Mathf.Abs(difX), Mathf.Abs(difY));
            float y = difY == 0 ? 0 : difY / Mathf.Max(Mathf.Abs(difX), Mathf.Abs(difY));
            Vector2 dir = new Vector2(x, y);
            for(int i = 0; i < transform.childCount; i++) {
                EngineController ec = transform.GetChild(i).GetComponent<EngineController>();
                if(ec != null) {
                    ec.dir = dir;
                    break;
                }
            }
            timeBeForced = 1f;
            OnDamage(damage.damage);
        }
    }
}
