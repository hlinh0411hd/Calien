using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    // Start is called before the first frame update

    public float health = 0;
    public float maxHealth = 0;
    public float minHealth = 0;

    void Start() {

    }

    public void AddHealth(float h) {
        health += h;
        if (health > maxHealth) {
            health = maxHealth;
        }
    }

    public bool SubHealth(float h) {
        health -= h;
        if (health < minHealth) {
            health = minHealth;
            return true;
        }
        return false;
    }
}
