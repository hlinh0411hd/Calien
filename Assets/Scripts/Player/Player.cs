using UnityEngine;
using System.Collections;

public class Player : APlayer
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("direct " + direct);
    }

    protected override void OnFire()
    {
        throw new System.NotImplementedException();
    }

    protected override void Move()
    {
        Vector2 position = transform.position;
        position.x += hor * speed;
        position.y += vert * speed;
        transform.position = position;

        float angle = (vert >= 0 ? 90 : -90);
        if (hor != 0)
        {
            if (vert != 0)
            {
                angle = Mathf.Atan(vert / hor) / Mathf.PI * 180;
                if (hor < 0 && vert < 0)
                {
                    angle -= 180;
                }

                if (hor < 0 && vert > 0)
                {
                    angle += 180;
                }
            } else
            {
                angle = hor > 0 ? 0 : 180;
            }
        }
        if (-22.5 < angle && angle <= 22.5) {
            direct = DIRECT.EAST;
        }
        if (22.5 < angle && angle <= 67.5) {
            direct = DIRECT.NORTH_EAST;
        }
        if (67.5 < angle && angle <= 112.5) {
            direct = DIRECT.NORTH;
        }
        if(112.5 < angle && angle <= 157.5) {
            direct = DIRECT.NORTH_WEST;
        }
        if(157.5 < angle || angle <= -157.5) {
            direct = DIRECT.WEST;
        }
        if(-157.5 < angle && angle <= -112.5) {
            direct = DIRECT.SOUTH_WEST;
        }
        if(-112.5 < angle && angle <= -67.5) {
            direct = DIRECT.SOUTH;
        }
        if(-67.5 < angle && angle <= -22.5) {
            direct = DIRECT.SOUTH_EAST;
        }
    }

    protected override void DoAction()
    {
    }
}
