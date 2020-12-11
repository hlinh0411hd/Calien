using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void offsetTexture(Vector2 offset) 
    {
        Vector2 lastOffset = GetComponent<Renderer>().material.mainTextureOffset;
        GetComponent<Renderer>().material.mainTextureOffset = lastOffset + offset * speed; 
    }
}
