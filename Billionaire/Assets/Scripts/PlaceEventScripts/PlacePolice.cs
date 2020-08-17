using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlacePolice : MonoBehaviour
{

    public GameObject panelEvent;
    public Text TextMess;

    [HideInInspector]
    public static bool ProvSetPanel = false, ProvSetMessage = false;

    string[] MassMessage;
    string Mess;
    int RanNum;

    // Start is called before the first frame update
    void Start()
    {
        ProvSetPanel = false;
        ProvSetMessage = false;

        MassMessage = new string[4];

        MassMessage[0] = "Все документы в порядке. Просто пропустите ход.";
        MassMessage[1] = "Вас оштрафовали за нарушение на 200.";
        MassMessage[2] = "Вас оштрафовали за нарушение на 500.";
        MassMessage[3] = "Вы предложили взятку инспектору.";
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
            TextMess.text = Mess;
        }
        else TextMess.text = "";
    }

    public void But_RanMessage()
    {
        if (ProvSetMessage == false)
        {
            System.Random rnd = new System.Random();
            RanNum = rnd.Next(0, 6);

            if (RanNum == 0 || RanNum == 1 || RanNum == 2)
            {
                Mess = MassMessage[0];
                ProvSetMessage = true;
                Player_Script.Mass_Player[Player_Script.Score].SkipMovePolice = 2;
            }
            else if (RanNum == 3)
            {
                Mess = MassMessage[1];
                ProvSetMessage = true;
                Player_Script.Mass_Player[Player_Script.Score].Money -= 200;
                PanelMenu.MoneyBank += 200;
            }
            else if (RanNum == 4)
            {
                Mess = MassMessage[2];
                ProvSetMessage = true;
                Player_Script.Mass_Player[Player_Script.Score].Money -= 500;
                PanelMenu.MoneyBank += 500;
            }
            else if (RanNum == 5)
            {
                RanNum = rnd.Next(1,7);

                if (RanNum < 4)
                {
                    Mess = MassMessage[3] + " И он согласился на 100, можете продолжить путь!";
                    Player_Script.Mass_Player[Player_Script.Score].Money -= 100;
                }
                else
                {
                    Mess = MassMessage[3] + " И он отказался. Вы попали за решетку на два хода, и штраф 500.";
                    ProvSetMessage = true;
                    Player_Script.Mass_Player[Player_Script.Score].SkipMovePolice = 3;
                    Player_Script.Mass_Player[Player_Script.Score].Money -= 500;
                    PanelMenu.MoneyBank += 500;
                }
            }
        }
    }

    public void But_Back()
    {
        if (ProvSetMessage == true)
        {
            panelEvent.SetActive(false);
            ProvSetMessage = false;
            Mess = "";
        }
    }
}
