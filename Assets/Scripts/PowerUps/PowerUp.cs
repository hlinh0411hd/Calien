using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public int id;
    public float speed;

    public int maxAdd;
    public int currentAdd;

    Rigidbody2D rb;

    public Vector2 dir = new Vector2(0, 0);

    private GameObject gameController;

    private PowerUpController powerUpController;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameController = GameObject.Find("GameController");
        powerUpController = gameController.GetComponent<PowerUpController>();
    }

    private void FixedUpdate()
    {
        rb.velocity = dir * speed; 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject objectCollider = other.gameObject;
        switch (objectCollider.tag)
        {
            case "Player":
                powerUpController.OnDestroyPowerUp(id);
                Destroy(gameObject);
                break;
        }

    }
}
