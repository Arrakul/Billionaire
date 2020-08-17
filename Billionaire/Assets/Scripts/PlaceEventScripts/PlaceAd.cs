using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceAd : MonoBehaviour
{
    public GameObject panelAd;

    [HideInInspector]
    public static bool ProvSetPanel = false;

    // Start is called before the first frame update
    void Start()
    {
        ProvSetPanel = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ProvSetPanel == true)
        {
            panelAd.SetActive(true);
            ProvSetPanel = false;
        }
    }

    public void But_Ok()
    {
        if (Player_Script.Mass_Player[Player_Script.Score].Money >= 1000)
        {
            Player_Script.Mass_Player[Player_Script.Score].Money -= 1000;
            if (Player_Script.Mass_Player[Player_Script.Score].Reputation < 4) Player_Script.Mass_Player[Player_Script.Score].Reputation += 1;
            PanelMenu.MoneyBank += 1000;
            panelAd.SetActive(false);
        }
    }

    public void But_No()
    {
        panelAd.SetActive(false);
    }
}
