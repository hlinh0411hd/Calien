using UnityEngine;
using System.Collections;

public abstract class RotableFunc : AFunc {

    public float angle;
    private float rateChange;
    public float valueChange;

    protected override void ChangePosition() {
        if(isChosen == true) {
            transform.RotateAround(anchorPoint, Vector3.forward, angle * hor);
        } else {
            if(Random.Range(0f, 1000f) < rateChange) {
                valueChange = -valueChange;
                rateChange = 0;
            } else {
                rateChange += 0.05f;
            }
            transform.RotateAround(anchorPoint, Vector3.forward, angle * valueChange);
        }
    }

}
