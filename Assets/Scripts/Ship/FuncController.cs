using UnityEngine;
using System.Collections;

public class FuncController : MonoBehaviour {

    public const int ENGINE = 0;
    public const int GUN = 1;
    public const int SHEILD = 2;

    public GameObject[] funcPrefabs;
    public float timeChangeFunc;
    private float currentTimeChangeFunc;

    private int currentFunc;

    public ArrayList listCurrentFuncInShip;

    // Use this for initialization
    void Start() {
        listCurrentFuncInShip = new ArrayList();
        currentFunc = -1;
        InitFuncShip();
        currentTimeChangeFunc = 0;
    }

    void InitFuncShip() {
        for (int i = 0; i < funcPrefabs.Length; i++) {
            var index = i;
            AddFuncToShip(index);
        }
        UpdateFuncShip();
    }

    // Update is called once per frame
    void Update() {

        //currentTimeChangeFunc -= Time.deltaTime;
        //if(currentTimeChangeFunc < 0) {
        //    currentTimeChangeFunc = timeChangeFunc;
        //    ChangeFuncShip();
        //    foreach (GameObject obj in listCurrentFuncInShip) {
        //        obj.GetComponent<AFunc>().SetIsChosen(currentFunc);
        //    }
        //}
    }

    public void UpdateFuncShip()
    {
        ChangeFuncShip();

        foreach (GameObject obj in listCurrentFuncInShip)
        {
            obj.GetComponent<AFunc>().SetIsChosen(currentFunc);
        }
    }

    public void ChangeFuncShip() {
        bool isFound = false;
        foreach(GameObject obj in listCurrentFuncInShip) {
            if(isFound == false) {
                if(obj.GetComponent<AFunc>().id == currentFunc) {
                    isFound = true;
                }
            } else {
                currentFunc = obj.GetComponent<AFunc>().id;
                return;
            }
        }
        if (listCurrentFuncInShip.Count == 0) {
            currentFunc = -1;
            return;
        }
        currentFunc = ( (GameObject) listCurrentFuncInShip[0]).GetComponent<AFunc>().id;
    }

    public void AddFuncToShip(int index) {
        GameObject func = Instantiate(funcPrefabs[index]);
        func.transform.SetParent(transform);
        Vector3 pos = transform.position;
        pos.y += GetComponent<Renderer>().bounds.size.y * 0.65f;
        func.transform.position = pos;
        func.transform.RotateAround(transform.position, Vector3.forward, Random.Range(0, 360));
        listCurrentFuncInShip.Add(func);
    }

    public int GetCurrentFunc() {
        return currentFunc;
    }

    public void ResetOverLoad()
    {
        ((GameObject)listCurrentFuncInShip[currentFunc]).GetComponent<AFunc>().currentTimeChoosing = 0;
    }

    public int GetNumFunc()
    {
        return listCurrentFuncInShip.Count;
    }

    public GameObject GetFunc(int id)
    {
        foreach (GameObject go in listCurrentFuncInShip)
        {
            if (go.GetComponent<AFunc>().id == id)
            {
                return go;
            }
        }
        return null;
    }
}
