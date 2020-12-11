using UnityEngine;
using System.Collections;

public abstract class ABullet : MonoBehaviour {

    public float speed;

    protected Vector3 dir;

    protected Rigidbody2D rb;

    protected void Start() {
        rb = GetComponent<Rigidbody2D>();
        dir = transform.up;

    }

    protected void FixedUpdate() {
        Move();
    }

    protected abstract void Move();
}
