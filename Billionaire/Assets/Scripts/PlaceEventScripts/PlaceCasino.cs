using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlaceCasino : MonoBehaviour
{

    public GameObject panelCasino1;
    public GameObject panelCasino2;
    public GameObject panelCasino3;

    public GameObject panelcolor;
    public Text text, textfinale;

    [HideInInspector]
    public static bool ProvSetPanel = false;

    [HideInInspector]
    public static int CanNum, MyNum, Sum = 0;

    System.Random rnd;
    bool ProvRan = false;

    // Start is called before the first frame update
    void Start()
    {
        ProvSetPanel = false;

        CanNum = 0;
        MyNum = 0;
        Sum = 0;

        rnd = new System.Random();
        ProvRan = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ProvSetPanel == true)
        {
            panelCasino1.SetActive(true);
            ProvSetPanel = false;
        }
        else if (panelCasino2.activeInHierarchy == true)
        {
            text.text = MyNum.ToString() + " - " + CanNum.ToString() + " = " + Sum;

            if (Sum > 0) panelcolor.GetComponent<Image>().color = Color.green;
            else panelcolor.GetComponent<Image>().color = Color.red;
        }
        else if (panelCasino3.activeInHierarchy == true)
        {
            if (Sum > 0) textfinale.text = "Вы выйграли (" + (Sum*100) + ")!";
            if (Sum < 0) textfinale.text = "Вы проиграли (" + (Sum * 100) + ")!";
            if (Sum == 0) textfinale.text = "Вы ничего не выиграли!";
        }
    }

    public void But_RanNum()
    {
        if (ProvRan == false)
        {
            MyNum = rnd.Next(1,7);
            Sum = MyNum - CanNum;
            ProvRan = true;
        }
    }

    public void But_Ok()
    {
        if (panelCasino1.activeInHierarchy == true)
        {
            panelCasino2.SetActive(true);
            panelCasino1.SetActive(false);

            CanNum = rnd.Next(1,7);
        } 
        else if (panelCasino2.activeInHierarchy == true)
        {
            panelCasino2.SetActive(false);
            panelCasino3.SetActive(true);
        }
        else if (panelCasino3.activeInHierarchy == true)
        {
            Player_Script.Mass_Player[Player_Script.Score].Money += (Sum * 100);
            panelCasino3.SetActive(false);
            CanNum = 0;
            MyNum = 0;
            Sum = 0;
            ProvRan = false;
        }
    }

    public void But_No()
    {
        panelCasino1.SetActive(false);
        ProvRan = false;
    }
}
