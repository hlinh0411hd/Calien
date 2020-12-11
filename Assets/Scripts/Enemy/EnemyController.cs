using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameController gameController;
    public GameObject target;

    private float lastTimeCreateBomber;
    public GameObject bomberPrefabs;

    private float lastTimeCreateShooter;
    public GameObject shooterPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        lastTimeCreateBomber = -4;
        lastTimeCreateShooter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.timePlay < 30)
        {
            if (gameController.timePlay - lastTimeCreateBomber > 8)
            {
                CreateBomber();
                lastTimeCreateBomber = gameController.timePlay;
            }
        } else
        {
            FuncController funcController = target.GetComponent<FuncController>();
            if (funcController.GetNumFunc() <= 2)
            {
                if (gameController.timePlay - lastTimeCreateBomber > 8)
                {
                    CreateBomber();
                    lastTimeCreateBomber = gameController.timePlay;
                }
                if (gameController.timePlay - lastTimeCreateShooter > 13)
                {
                    CreateShooter();
                    lastTimeCreateShooter = gameController.timePlay;
                }
            } else
            {
                if (gameController.timePlay - lastTimeCreateBomber > 5)
                {
                    CreateBomber();
                    lastTimeCreateBomber = gameController.timePlay;
                }
                if (gameController.timePlay - lastTimeCreateShooter > 10)
                {
                    CreateShooter();
                    lastTimeCreateShooter = gameController.timePlay;
                }
            }
        }
    }

    void CreateBomber()
    {
        float x = Random.Range(-1f, 2f);
        float y = Random.Range(-1f, 2f);
        if (Random.Range(0f, 100f) < 50f)
        {
            if (x >= 0 && x < 0.5) x = 0;
            if (x >= 0.5 && x < 1) x = 1;
        } else
        {
            if (y >= 0 && y < 0.5) y = 0;
            if (y >= 0.5 && y < 1) y = 1;
        }
        Vector3 positionSpawn = Camera.main.ViewportToWorldPoint(new Vector3(x, y, 1));
        GameObject bomber = Instantiate(bomberPrefabs, positionSpawn, Quaternion.identity);
        bomber.GetComponent<AEnemy>().target = target;
    }

    void CreateShooter()
    {
        float x = Random.Range(-1f, 2f);
        float y = Random.Range(-1f, 2f);
        if (Random.Range(0f, 100f) < 50f)
        {
            if (x >= 0 && x < 0.5) x = 0;
            if (x >= 0.5 && x < 1) x = 1;
        }
        else
        {
            if (y >= 0 && y < 0.5) y = 0;
            if (y >= 0.5 && y < 1) y = 1;
        }
        Vector3 positionSpawn = Camera.main.ViewportToWorldPoint(new Vector3(x, y, 1));
        GameObject shooter = Instantiate(shooterPrefabs, positionSpawn, Quaternion.identity);
        shooter.GetComponent<AEnemy>().target = target;
    }
}
