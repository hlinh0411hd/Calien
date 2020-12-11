using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{

    public const int HEAL = 0;
    public const int CHANGE_FUNC = 1;
    public const int REMOVE_OVERLOAD = 2;

    public const int ADD_GUN = 3;
    public const int ADD_SHEILD = 4;

    public GameObject[] listPowerUps;
    public float timeAddPowerUp;
    public float currentTime;

    private bool isFirst;

    public GameController gameController;

    private FuncController funcController;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 10;
        isFirst = false;
        foreach (GameObject obj in listPowerUps)
        {
            obj.GetComponent<PowerUp>().currentAdd = 0;
        }

        funcController = gameController.mainShip.GetComponent<FuncController>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime < 0)
        {
            CreatePowerUp();
            currentTime = timeAddPowerUp;
        }

    }

    void CreatePowerUp()
    {
        int id;
        int length = listPowerUps.Length;
        id = Mathf.RoundToInt(Random.Range(0, length));
        for (int index = id % length; index != (id - 1 + length) % length; index = (index + 1) % length)
        {
            PowerUp powerUp = listPowerUps[index].GetComponent<PowerUp>();
            if (powerUp.maxAdd == -1 || powerUp.currentAdd < powerUp.maxAdd)
            {
                id = index;
                break;
            }
        }

        PowerUp powerUp1 = listPowerUps[id].GetComponent<PowerUp>();
        if (powerUp1.maxAdd == -1 || powerUp1.currentAdd < powerUp1.maxAdd)
        {
        } else
        {
            return;
        }

        GameObject go = listPowerUps[id];

        float x = Random.Range(0f, 1f);
        float y = Random.Range(0f, 1f);
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
        GameObject pw = Instantiate(go, positionSpawn, Quaternion.identity);
        if (isFirst == true)
        {
            float dirX = (1 - 2 * x) < 0 ? Random.Range(-1f, -0.3f) : Random.Range(0.3f, 1f);
            float dirY = (1 - 2 * y) < 0 ? Random.Range(-1f, -0.3f) : Random.Range(0.3f, 1f);
            pw.GetComponent<PowerUp>().dir = new Vector2(dirX, dirY);
        } else
        {
            Vector2 start = positionSpawn;
            Vector2 end = gameController.mainShip.transform.position;
            float dirX = (end.x - start.x) / Mathf.Max(Mathf.Abs(end.x - start.x), Mathf.Abs(end.y - start.y));
            float dirY = (end.y - start.y) / Mathf.Max(Mathf.Abs(end.x - start.x), Mathf.Abs(end.y - start.y));
            pw.GetComponent<PowerUp>().dir = new Vector2(dirX, dirY);
        }
    }

    public void OnDestroyPowerUp(int id)
    {
        GameObject go;
        switch (id)
        {
            case HEAL:
                gameController.mainShip.GetComponent<ShipController>().AddHealth(15);
                break;
            case CHANGE_FUNC:
                funcController.UpdateFuncShip();
                break;
            case REMOVE_OVERLOAD:
                break;
            case ADD_GUN:
                go = funcController.GetFunc(FuncController.GUN);
                if (go != null)
                {
                    go.GetComponent<AFunc>().SetLevel(go.GetComponent<AFunc>().level + 1);
                }
                break;
            case ADD_SHEILD:
                go = funcController.GetFunc(FuncController.SHEILD);
                if (go != null)
                {
                    go.GetComponent<AFunc>().SetLevel(go.GetComponent<AFunc>().level + 1);
                }
                break;
        }
    }
}
