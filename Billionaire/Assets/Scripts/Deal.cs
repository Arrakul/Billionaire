using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deal : MonoBehaviour
{
    public GameObject deal;
    public GameObject bargaining;

    [HideInInspector]
    public static bool Check;

    const string TagPlaceDefault = "Place";
    static string TagPlace;
    static bool Status;
    static int Chips;

    public void But_Ok()
    {
        deal.SetActive(false);
        bargaining.SetActive(true);

        //Bargaining.player = player;
    }

    public static void UpdateDataInDeal()
    {
        Status = Player_Script.Mass_Player[Player_Script.Score].other.gameObject.GetComponent<Place_Script>().status;
        TagPlace = Player_Script.Mass_Player[Player_Script.Score].other.tag;
        Chips = Player_Script.Mass_Player[Player_Script.Score].Chips;
    }

    public void But_ShowBargaining()
    {
        //Status = Player_Script.Mass_Player[Player_Script.Score].other.gameObject.GetComponent<Place_Script>().status;
        //TagPlace = Player_Script.Mass_Player[Player_Script.Score].other.tag;

        UpdateDataInDeal();

        Debug.Log("Check = " + Check + " TagPlace = " + TagPlace + " Status = " + Status);
        if (Check == false && TagPlace == TagPlaceDefault && Status == false && Chips > 0)
        {
            bargaining.SetActive(true);
            //Bargaining.player = player;
            Check = true;
            RollTheDice_Scripts.Prov = false;
        }
    }

    public void But_No()
    {
        deal.SetActive(false);
    }
}
