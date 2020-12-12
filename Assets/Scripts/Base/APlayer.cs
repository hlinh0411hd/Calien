using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class APlayer : MonoBehaviour
{

    public float speed;

    protected float hor;
    protected float vert;


    public float timeDelayFire;
    protected float currentTimeDelayFire;


    protected void FixedUpdate()
    {
        hor = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");
        Move();


        if (Input.GetButton("Fire1"))
        {
            if (currentTimeDelayFire < 0)
            {
                OnFire();
                currentTimeDelayFire = timeDelayFire;
            }
        }

        if (Input.GetButton("Fire2"))
        {
            DoAction();
        }
    }

    protected abstract void Move();
    protected abstract void OnFire();
    protected abstract void DoAction();
}
