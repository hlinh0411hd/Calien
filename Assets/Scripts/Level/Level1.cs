using System.Collections;
using UnityEngine;

public class Level1: ALevel
{
    public Level1()
    {
        listPositionPlanet = new ArrayList();
        WIDTH = 100;
        HEIGHT = 200;
        NUM_PLANET = 10;
        SetUpPlanet();
    }

    public void SetUpPlanet()
    {
        float x = 5;
        float y = -20;
        for (int i = 0; i < NUM_PLANET; i++)
        {
            x = Random.Range(-WIDTH, WIDTH);
            y = y + 40 - Random.Range(5, 10);
            Vector2 vec = new Vector2(x, y);
            listPositionPlanet.Add(vec);
        }
    }
}
