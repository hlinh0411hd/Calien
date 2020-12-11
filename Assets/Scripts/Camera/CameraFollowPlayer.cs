using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public GameObject followTarget;
    public GameObject[] background;

    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    private float cameraZ = 0;

    private Camera camera;

    void Start()
    {
        cameraZ = transform.position.z;
        camera = GetComponent<Camera>();
    }

    void FixedUpdate()
    {
        if (followTarget)
        {
            Vector3 delta = followTarget.transform.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, cameraZ));
            Vector3 destination = transform.position + delta;
            destination.z = cameraZ;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);

            for (int i = 0; i < background.Length; i++)
            {
                BackgroundScroller scroller = background[i].GetComponent<BackgroundScroller>();
                if (scroller)
                {
                    scroller.offsetTexture(new Vector2(delta.x, delta.y));
                }
            }
        }
    }
}