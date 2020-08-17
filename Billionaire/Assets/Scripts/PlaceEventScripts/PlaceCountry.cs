using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlaceCountry : MonoBehaviour
{

    public GameObject panelEvent;
    public Text TextMessage;

    [HideInInspector]
    public static bool ProvSetPanel = false, ProvSetMessage = false;

    static int Indx = 0, Indx2 = 0;
    string[][] MassMessage;

    // Start is called before the first frame update
    void Start()
    {
        ProvSetPanel = false;
        ProvSetMessage = false;
        Indx = 0;
        Indx2 = 0;

        MassMessage = new string[5][];

        MassMessage[0] = new string[] { "Чиновник вымогал взятку. Пришлось отдать 100 в Банк." };
        MassMessage[1] = new string[6] 
        {
            "Правительство России вводит новый налог. Если вам принадлежат клетки в этой стране, заплатите в Банк 100, за каждую.",
            "Правительство ЕС вводит новый налог. Если вам принадлежат клетки в этой стране, заплатите в Банк 100, за каждую.",
            "Правительство Китая вводит новый налог. Если вам принадлежат клетки в этой стране, заплатите в Банк 100, за каждую.",
            "Правительство Канады вводит новый налог. Если вам принадлежат клетки в этой стране, заплатите в Банк 100, за каждую.",
            "Правительство США вводит новый налог. Если вам принадлежат клетки в этой стране, заплатите в Банк 100, за каждую.",
            "Правительство Японии вводит новый налог. Если вам принадлежат клетки в этой стране, заплатите в Банк 100, за каждую."
        };
        MassMessage[2] = new string[6]
        {
            "Экономические реформы России принесли вам прибыль. Если вы имеете в этой стране клетки, получите из банка 500.",
            "Экономические реформы ЕС принесли вам прибыль. Если вы имеете в этой стране клетки, получите из банка 500.",
            "Экономические реформы Китая принесли вам прибыль. Если вы имеете в этой стране клетки, получите из банка 500.",
            "Экономические реформы Канады принесли вам прибыль. Если вы имеете в этой стране клетки, получите из банка 500.",
            "Экономические реформы США принесли вам прибыль. Если вы имеете в этой стране клетки, получите из банка 500.",
            "Экономические реформы Японии принесли вам прибыль. Если вы имеете в этой стране клетки, получите из банка 500."
        };
        MassMessage[3] = new string[6]
        {
            "Государственные инвестиции принесли владельцам построек в России по 300, за каждую клетку.",
            "Государственные инвестиции принесли владельцам построек в ЕС по 300, за каждую клетку.",
            "Государственные инвестиции принесли владельцам построек в Китае по 300, за каждую клетку.",
            "Государственные инвестиции принесли владельцам построек в Канаде по 300, за каждую клетку.",
            "Государственные инвестиции принесли владельцам построек в США по 300, за каждую клетку.",
            "Государственные инвестиции принесли владельцам построек в Японии по 300, за каждую клетку."
        };
        MassMessage[4] = new string[6]
        {
            "Смена курса России привела к расходам. Все игроки чья фишка сейчас находиться на одной из клеток этой страны, платят в банк 500.",
            "Смена курса ЕС привела к расходам. Все игроки чья фишка сейчас находиться на одной из клеток этой страны, платят в банк 500.",
            "Смена курса Китая привела к расходам. Все игроки чья фишка сейчас находиться на одной из клеток этой страны, платят в банк 500.",
            "Смена курса Канады привела к расходам. Все игроки чья фишка сейчас находиться на одной из клеток этой страны, платят в банк 500.",
            "Смена курса США привела к расходам. Все игроки чья фишка сейчас находиться на одной из клеток этой страны, платят в банк 500.",
            "Смена курса Японии привела к расходам. Все игроки чья фишка сейчас находиться на одной из клеток этой страны, платят в банк 500."
        };
    }

    // Update is called once per frame
    void Update()
    {
        if (ProvSetPanel == true)
        {
            panelEvent.SetActive(true);
            ProvSetPanel = false;
        }

        if (ProvSetMessage == true)
        {
            TextMessage.text = MassMessage[Indx][Indx2];
        }
        else TextMessage.text = "";
    }

    public void But_RanMessage()
    {
        if (ProvSetMessage == false)
        {
            System.Random rnd = new System.Random();
            Indx = rnd.Next(0, 5);

            PanelMenu.MoneyFond += 100;

            if (Player_Script.Mass_Player[Player_Script.Score].First_Сaptured == true)
            {
                Debug.Log("IndxPlace = " + Indx);
                Indx = 0;
            }

            if (Indx == 0) //"Чиновник вымогал взятку. Пришлось отдать 100 в Банк."
            {
                Player_Script.Mass_Player[Player_Script.Score].Money -= 100;
                PanelMenu.MoneyBank += 100;
                Indx2 = 0;
            }
            else if (Indx == 1) //"Правительство России вводит новый налог. Если вам принадлежат клетки в этой стране, заплатите в Банк 100, за каждую."
            {
                Indx2 = rnd.Next(0,6); 

                foreach (var place in Player_Script.Mass_Player[Player_Script.Score].MassPlacePlayer)
                {
                    Debug.Log("Place.Indx = " + place.Indx1 + "/ Indx2 = " + (Indx2+1));
                    if (place.Indx1 == (Indx2+1))
                    {
                        Player_Script.Mass_Player[Player_Script.Score].Money -= 100;
                        PanelMenu.MoneyBank += 100;
                    }
                }
            }
            else if (Indx == 2) //"Экономические реформы России принесли вам прибыль. Если вы имеете в этой стране клетки, получите из банка 500."
            {
                Indx2 = rnd.Next(0, 6);

                foreach (var place in Player_Script.Mass_Player[Player_Script.Score].MassPlacePlayer)
                {
                    Debug.Log("Place.Indx = " + place.Indx1 + "/ Indx2 = " + (Indx2 + 1));
                    if (place.Indx1 == (Indx2 + 1))
                    {
                        Player_Script.Mass_Player[Player_Script.Score].Money += 500;
                        PanelMenu.MoneyBank -= 500;
                        break;
                    }
                }
            }
            else if (Indx == 3) //"Государственные инвестиции принесли владельцам построек в Японии по 300, за каждую клетку."
            {
                Indx2 = rnd.Next(0, 6);
                foreach (Player player in Player_Script.Mass_Player)
                {
                    Debug.Log("Player = " + player.tag + "/ Count = " + player.MassPlacePlayer.Count);

                    foreach (var place in player.MassPlacePlayer)
                    {
                        Debug.Log("Place.Indx = " + place.Indx1 + "/ Indx2 = " + (Indx2 + 1));
                        if (place.Indx1 == (Indx2 + 1))
                        {
                            player.Money += 300;
                        }
                    }
                }
            }
            else if (Indx == 4) //"Смена курса Японии привела к расходам. Все игроки чья фишка сейчас находиться на одной из клеток этой страны, платят в банк 500."
            {
                Indx2 = rnd.Next(0, 6);
                foreach (Player player in Player_Script.Mass_Player)
                {
                    if (player.other != null)
                    {
                        Debug.Log("Player = " + player.tag + "/ Count = " + player.other.gameObject.GetComponent<Place_Script>().Indx1);
                        if (player.other.gameObject.GetComponent<Place_Script>().Indx1 == (Indx2+1))
                        {
                            player.Money -= 500;
                            PanelMenu.MoneyBank += 500;
                        }
                    }
                }
            }

            ProvSetMessage = true;
        }
    }

    public void But_Back()
    {
        if (ProvSetMessage == true)
        {
            panelEvent.SetActive(false);
            ProvSetMessage = false;
        }
    }
}
