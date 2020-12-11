using UnityEngine;
using System.Collections;

public class ShieldController : RotableFunc {

    public float timePush;
    public float currentTimePush;

    private float baseAngle;
    public float overloadAngle;

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

        }
        if (currentTimeChoosing < timeOverload)
        {
            currentTimePush = timePush;
        }
    }

    // Use this for initialization
    new void Start() {
        base.Start();
        baseAngle = angle;
    }

    new void FixedUpdate()
    {
        base.FixedUpdate();

        if (currentTimePush >= 0)
        {
            currentTimePush -= Time.deltaTime;
        }

        if (currentTimeChoosing > timeOverload)
        {
            angle = overloadAngle;
        }
        else
        {
            angle = baseAngle;
        }
    }
}
