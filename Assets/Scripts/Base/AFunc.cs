using UnityEngine;
using System.Collections;

public abstract class AFunc : MonoBehaviour {

    public int id;
    public bool isChosen;


    protected float vert;
    protected float hor;
    protected Vector3 anchorPoint;

    public float timeDelayFire;
    protected float currentTimeDelayFire;

    public float timeDelayChoosing;
    public float currentTimeDelayChoosing;

    public float timeOverload;
    public float currentTimeChoosing;

    public int level;

    protected void Start() {
        currentTimeDelayFire = timeDelayFire;
        SetLevel(0);
    }

    protected void FixedUpdate() {
        hor = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");
        if(transform.parent != null) {
            anchorPoint = transform.parent.transform.position;
            ChangePosition();
        }


        currentTimeDelayFire -= Time.deltaTime;
        if(Input.GetButton("Fire1")) {
            if(currentTimeDelayFire < 0) {
                if(isChosen) {
                    OnFire();
                    currentTimeDelayFire = timeDelayFire;
                }
            }
        }

        if (isChosen)
        {
            currentTimeChoosing += Time.deltaTime;
        } else
        {
            currentTimeDelayChoosing -= Time.deltaTime;
        }
    }

    public void SetIsChosen(int type) {
        if (id == type) {
            isChosen = true;
            currentTimeDelayChoosing = timeDelayChoosing;
            OnChosen();
        } else {
            isChosen = false;
            currentTimeChoosing = 0;
            OnChosen();
        }
    }

    public void SetLevel(int lv)
    {
        level = lv;
    }

    protected abstract void ChangePosition();
    protected abstract void OnChosen();
    protected abstract void OnFire();
}
