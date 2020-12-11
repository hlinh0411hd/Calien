using UnityEngine;
using System.Collections;

public class EngineController : RotableFunc {

    public float force;
    private float preventVel;
    private float baseForce;
    public float overloadForce;

    private float baseTimeDelayFire;
    public float overloadTimeDelayFire;

    public Vector2 dir;

    private Rigidbody2D rb;
    private ShipController sc;

    protected override void OnChosen() {
        if(isChosen) {
            transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
        } else {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    protected override void OnFire() {
        if (level >= 0)
        {
            if(sc.timeBeForced > 0) return;
            float difX = transform.parent.transform.position.x - transform.position.x;
            float difY = transform.parent.transform.position.y - transform.position.y;
            float x = difX == 0 ? 0 : difX / Mathf.Max(Mathf.Abs(difX), Mathf.Abs(difY));
            float y = difY == 0 ? 0 : difY / Mathf.Max(Mathf.Abs(difX), Mathf.Abs(difY));
            dir = new Vector2(x, y);
            rb.velocity = dir * force;
            preventVel = 1;
        }
    }

    // Use this for initialization
    new void Start() {
        base.Start();
        rb = transform.parent.GetComponent<Rigidbody2D>();
        sc = transform.parent.GetComponent<ShipController>();
        dir = new Vector2(0, 1);
        baseForce = force;
        baseTimeDelayFire = timeDelayFire;
    }


    new void FixedUpdate() {
        base.FixedUpdate();
        DecreaseVelocityParent();
        if (currentTimeChoosing > timeOverload)
        {
            force = overloadForce;
            timeDelayFire = overloadTimeDelayFire;
        }
        else
        {
            force = baseForce;
            timeDelayFire = baseTimeDelayFire;
        }
    }

    void AutoChangeParentPosition() {
        float difX = transform.parent.transform.position.x - transform.position.x;
        float difY = transform.parent.transform.position.y - transform.position.y;
        float x = difX == 0 ? 0 : difX / Mathf.Max(Mathf.Abs(difX), Mathf.Abs(difY));
        float y = difY == 0 ? 0 : difY / Mathf.Max(Mathf.Abs(difX), Mathf.Abs(difY));
        Vector2 dir = new Vector2(x, y);
        rb.velocity = dir * force / 3;
    }

    void DecreaseVelocityParent()
    {
        preventVel *= 0.95f;
        if (preventVel < 0.05) preventVel = 0f;
        rb.velocity = dir * preventVel * force;
    }
    // Update is called once per frame
    void Update() {

    }
}
