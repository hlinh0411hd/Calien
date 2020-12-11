using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeInTime : MonoBehaviour
{
    public float timeAlive;
    void Start()
    {
        StartCoroutine(IEnDestroyInTime(timeAlive));
    }

    // Update is called once per frame
    private IEnumerator IEnDestroyInTime(float time)
    {
        yield return new WaitForSeconds(time);

        Destroy(this.gameObject);
    }
}
