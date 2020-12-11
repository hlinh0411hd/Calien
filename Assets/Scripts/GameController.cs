using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject mainShipPrefab;
    public GameObject mainShip;
    public float timePlay;
    public FuncController funcController;
    public GUIController guiController;

    public GameObject[] listPlanetPrefabs;
    public ArrayList listPlanets;

    //info game
    private int level;
    private ALevel levelInfo;


    // Start is called before the first frame update
    void Start() {
        mainShip = Instantiate(mainShipPrefab);
        mainShip.transform.position = new Vector3(0, 0, 0);
        mainShip.name = "mainShip";
        mainShip.GetComponent<ShipController>().gameController = this;
        funcController = mainShip.GetComponent<FuncController>();

        listPlanets = new ArrayList();

        ChooseLevel(1);
        SetUpCamera();
        SetUpEnemy();
        SetUpGUI();

        timePlay = 0;
    }

    // Update is called once per frame
    void Update() {
        timePlay += Time.deltaTime;

        if (Input.GetKeyUp(KeyCode.A))
        {
            Debug.Log("PRESS A");
            funcController.UpdateFuncShip();
        }
    }

    void SetUpCamera()
    {
        GameObject.Find("Main Camera").GetComponent<CameraFollowPlayer>().followTarget = mainShip;
    }

    void SetUpEnemy()
    {
        GetComponent<EnemyController>().target = mainShip;
    }

    void SetUpGUI()
    {
        guiController.SetUp();
    }

    void ChooseLevel(int lv)
    {
        level = lv;
        switch (level)
        {
            case 1:
                levelInfo = (Level1)new Level1();
                SetUpLevel();
                break;
        }
    }

    void SetUpLevel()
    {
        foreach (GameObject planet in listPlanets)
        {
            Destroy(planet);
        }
        listPlanets = new ArrayList();
        for (var i = 0; i < levelInfo.listPositionPlanet.Count; i++)
        {
            GameObject planetFrefab = listPlanetPrefabs[(int) Math.Floor(UnityEngine.Random.Range(0f, listPlanetPrefabs.Length - 0.1f))];
            GameObject planet = Instantiate(planetFrefab);
            listPlanets.Add(planet);
            planet.transform.position = (Vector2) levelInfo.listPositionPlanet[i];
        }
    }
}
