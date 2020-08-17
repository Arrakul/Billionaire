using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelEvent : MonoBehaviour
{

    public GameObject panelEvent;
    public Text TextMessage;
        
    [HideInInspector]
    public static bool ProvSetPanel = false, ProvSetMessage = false;

    int Indx;
    string[] MassMessage;

    // Start is called before the first frame update
    void Start()
    {
        ProvSetPanel = false;
        ProvSetMessage = false;

        MassMessage = new string[6]
        {
            "Предприятие перевыполняет план. Вы выплатили премию сотрудникам, равную доходу предприятия. Ваша репутация увеличена на 1.",
            "Предприятие работает в соответствии с планом. Никому ничего не выплачиваем.",
            "Вы обнаружили и конфисковали 'левый' доход на предприятии. Вы получили из Банка 1000, но репутация уменьшилась на 1.",
            "Предприятие работает в соответствии с планом. Никому ничего не выплачиваем.",
            "Предприятие слегка отстает от плана. Инвестируем в него сумму равную половине дохода предприятия.",
            "Предприятие несет серьезные убытки. Инвестируем в него сумму равную доходу предприятия. Репутация уменьшена на 1."
        };
    }

    // Update is called once per frame
    void Update()
    {
        if (ProvSetPanel == true)
        {
            panelEvent.SetActive(true);
            ProvSetPanel = false;
            TextMessage.text = "";
        }

        if (ProvSetMessage == true)
        {
            TextMessage.text = MassMessage[Indx];
        }
    }

    public void But_RanMessage()
    {
        if (ProvSetMessage == false)
        {
            System.Random rnd = new System.Random();
            Indx = rnd.Next(0, 6);

            switch (Indx)
            {
                case 0:
                    PanelMenu.MoneyBank += Player_Script.Mass_Player[Player_Script.Score].other.gameObject.GetComponent<Place_Script>().money;
                    Player_Script.Mass_Player[Player_Script.Score].Money -= Player_Script.Mass_Player[Player_Script.Score].other.gameObject.GetComponent<Place_Script>().money;
                    if(Player_Script.Mass_Player[Player_Script.Score].Reputation < 4) Player_Script.Mass_Player[Player_Script.Score].Reputation++;
                    break;

                case 2:
                    PanelMenu.MoneyBank -= 1000;
                    Player_Script.Mass_Player[Player_Script.Score].Money += 1000;
                    if (Player_Script.Mass_Player[Player_Script.Score].Reputation > -4) Player_Script.Mass_Player[Player_Script.Score].Reputation--;
                    break;

                case 4:
                    PanelMenu.MoneyBank += Player_Script.Mass_Player[Player_Script.Score].other.gameObject.GetComponent<Place_Script>().money / 2;
                    Player_Script.Mass_Player[Player_Script.Score].Money -= Player_Script.Mass_Player[Player_Script.Score].other.gameObject.GetComponent<Place_Script>().money / 2;
                    break;

                case 5:
                    PanelMenu.MoneyBank += Player_Script.Mass_Player[Player_Script.Score].other.gameObject.GetComponent<Place_Script>().money;
                    Player_Script.Mass_Player[Player_Script.Score].Money -= Player_Script.Mass_Player[Player_Script.Score].other.gameObject.GetComponent<Place_Script>().money;
                    if (Player_Script.Mass_Player[Player_Script.Score].Reputation > -4)  Player_Script.Mass_Player[Player_Script.Score].Reputation--;
                    break;
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
