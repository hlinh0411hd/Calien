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
    }

    protected override void DoAction()
    {
        Debug.Log("HIHI");
    }
}
