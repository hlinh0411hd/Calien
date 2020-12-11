using UnityEngine;
using System.Collections;

public class GunController : RotableFunc {

    public float delayAuto;
    private float currentDelayAuto;

    public GameObject bullet;
    public Transform gunTransform;

    public float timeDelayFireOverLoad;
    private float timeDelayFireNormal;

    protected override void OnChosen() {
        if(isChosen) {
            transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
        } else {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    protected override void OnFire()
    {
        if (level >= 0)
        {
            transform.RotateAround(anchorPoint, Vector3.forward, angle * Random.Range(0f, 1f));
            GameObject clone = Instantiate(bullet, gunTransform.position, gunTransform.rotation);
        }
    }

    // Use this for initialization
    new void Start() {
        base.Start();
        currentDelayAuto = 0;
        timeDelayFireNormal = timeDelayFire;
    }

    // Update is called once per frame
    void Update() {

    }

    new void FixedUpdate() {
        base.FixedUpdate();
        if (currentTimeChoosing > timeOverload)
        {
            timeDelayFire = timeDelayFireOverLoad;
        } else
        {
            timeDelayFire = timeDelayFireNormal;
        }
        if(isChosen) {
        } else {
            currentDelayAuto -= Time.deltaTime;
            if(currentDelayAuto < 0) {
                OnFire();
                currentDelayAuto = delayAuto;
            }
        }
    }

}
