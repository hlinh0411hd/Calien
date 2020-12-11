using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{
    public Slider progressHealth;

    public Slider funcState;

    public GameController gameController;
    private FuncController funcController;

    private ArrayList listFuncState;

    // Use this for initialization
    public void SetUp()
    {
        listFuncState = new ArrayList();
        funcController = gameController.mainShip.GetComponent<FuncController>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthProgress();
        UpdateFuncState();
    }

    void UpdateHealthProgress()
    {
        Health mainHealth = gameController.mainShip.GetComponent<Health>();
        progressHealth.value = mainHealth.health / mainHealth.maxHealth;
    }

    void UpdateFuncState()
    {
        if (funcController == null) return;
        while (listFuncState.Count < funcController.listCurrentFuncInShip.Count)
        {
            Slider slider = (Slider) Instantiate(funcState);
            slider.transform.SetParent(transform);
            listFuncState.Add(slider);
            Vector2 pos = new Vector2(700, 300 - 90 * (listFuncState.Count - 1));
            slider.transform.position = pos;
            slider.transform.GetChild(0).GetComponent<Image>().sprite = ((GameObject)funcController.listCurrentFuncInShip[listFuncState.Count - 1]).GetComponent<SpriteRenderer>().sprite;
            slider.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = ((GameObject)funcController.listCurrentFuncInShip[listFuncState.Count - 1]).GetComponent<SpriteRenderer>().sprite;
        }

        for (int i = 0; i < listFuncState.Count; i++)
        {
            AFunc aFunc = ((GameObject)funcController.listCurrentFuncInShip[i]).GetComponent<AFunc>();
            if (aFunc.isChosen)
            {
                Slider sl = ((Slider)listFuncState[i]);
                sl.value = (aFunc.currentTimeChoosing / aFunc.timeOverload);
            } else
            {
                Slider sl = ((Slider)listFuncState[i]);
                sl.value = aFunc.currentTimeDelayChoosing / aFunc.timeDelayChoosing;
            }
        }
    }
}
