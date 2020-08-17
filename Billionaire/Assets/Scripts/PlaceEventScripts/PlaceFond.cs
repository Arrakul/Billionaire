using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceFond : MonoBehaviour
{
    public GameObject panelFond;

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
            panelFond.SetActive(true);
            ProvSetPanel = false;
        }
    }

    public void But_Ok()
    {
        Player_Script.Mass_Player[Player_Script.Score].Money += PanelMenu.MoneyFond;
        PanelMenu.MoneyFond = 0;
        panelFond.SetActive(false);
    }
}
