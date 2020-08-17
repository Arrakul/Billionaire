using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PanelSaleBank : MonoBehaviour
{

    public GameObject panelEvent;
    public Text textMess;

    [HideInInspector]
    public static bool ProvSetPanel = false, ProvPlace = false, ProvBank = false, ProvPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        ProvSetPanel = false;
        ProvPlace = false;
        ProvBank = false;
        ProvPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ProvSetPanel == true)
        {
            panelEvent.SetActive(true);
            ProvSetPanel = false;
        }

        textMess.text = PanelSalePlace.Mess;
    }

    public void But_OK()
    {
        Player_Script.Mass_Player[Player_Script.Score].Money += Player_Script.Mass_Player[Player_Script.Score].MassPlacePlayer[PanelSalePlace.IndxPlace].money;
        PanelMenu.MoneyBank -= Player_Script.Mass_Player[Player_Script.Score].MassPlacePlayer[PanelSalePlace.IndxPlace].money;

        Player_Script.Mass_Player[Player_Script.Score].MassPlacePlayer[PanelSalePlace.IndxPlace].status = false;
        Player_Script.Mass_Player[Player_Script.Score].MassPlacePlayer[PanelSalePlace.IndxPlace].TAG = "0";

        Debug.Log("IndxPlace = " + PanelSalePlace.IndxPlace);
        Player_Script.Mass_Player[Player_Script.Score].MassPlacePlayer.RemoveAt(PanelSalePlace.IndxPlace);

        Destroy(Player_Script.Mass_Player[Player_Script.Score].MassPointPlayer[PanelSalePlace.IndxPlace]);
        Player_Script.Mass_Player[Player_Script.Score].MassPointPlayer.RemoveAt(PanelSalePlace.IndxPlace);

        PanelSalePlace.Mess = "";
        panelEvent.SetActive(false);
    }

    public void But_Back()
    {
        panelEvent.SetActive(false);
        PanelSalePlace.Mess = "";
    }
}
