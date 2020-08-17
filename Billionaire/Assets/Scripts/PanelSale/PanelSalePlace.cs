using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PanelSalePlace : MonoBehaviour
{
    public GameObject panelEvent;
    public Dropdown dropdown1, dropdown2;
    public Button But_ok;

    [HideInInspector]
    public static bool ProvSetPanel = false, ProvPlace = false, ProvBank = false, ProvPlayer = false;

    [HideInInspector]
    public static int Indx1 = 1, Indx2 = 1, IndxPlace = -1;

    [HideInInspector]
    public static string Mess;

    [HideInInspector]
    public Place_Script MyPlace;

    ColorBlock mycolor;

    // Start is called before the first frame update
    void Start()
    {
        ProvSetPanel = false;
        ProvPlace = false;
        ProvBank = false;
        ProvPlayer = false;

        Indx1 = 1;
        Indx2 = 1;
        IndxPlace = -1;

        Mess = "";
        MyPlace = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (ProvSetPanel == true)
        {
            panelEvent.SetActive(true);
            ProvSetPanel = false;
        }
    }

    public void But_OK()
    {
        if (ProvPlace == true && ProvBank == true)
        {
            PanelSaleBank.ProvSetPanel = true;

            Mess += dropdown2.options[Indx2 - 1].text + " за " + MyPlace.money;

            ProvBank = false;
            panelEvent.SetActive(false);
            ProvPlace = false;
        }
        else if (ProvPlace == true && ProvPlayer == true)
        {
            ProvPlayer = false;
            panelEvent.SetActive(false);
            ProvPlace = false;
        }
    }

    public void ChangeValue()
    {
        Debug.Log("Drop1 = " + dropdown1.value);

        if (dropdown1.value == 0)
        {
            Indx1 = 1;
            Mess = "В России, в городе ";
            dropdown2.captionText.text = "Москва";

            dropdown2.options[0].text = "Москва";
            dropdown2.options[1].text = "Санкт-Петербург";
            dropdown2.options[2].text = "Казань";
            dropdown2.options[3].text = "Новосибирск";
        }
        else if (dropdown1.value == 1)
        {
            Indx1 = 2;
            Mess = "В ЕС, в городе ";
            dropdown2.captionText.text = "Берлин";

            dropdown2.options[0].text = "Берлин";
            dropdown2.options[1].text = "Париж";
            dropdown2.options[2].text = "Рим";
            dropdown2.options[3].text = "Вена";
        }
        else if (dropdown1.value == 2)
        {
            Indx1 = 3;
            Mess = "В Катае, в городе ";
            dropdown2.captionText.text = "Пекин";

            dropdown2.options[0].text = "Пекин";
            dropdown2.options[1].text = "Шанхай";
            dropdown2.options[2].text = "Тяньцзинь";
            dropdown2.options[3].text = "Шеньян";
        }
        else if (dropdown1.value == 3)
        {
            Indx1 = 4;
            Mess = "В Канаде, в городе ";
            dropdown2.captionText.text = "Оттава";

            dropdown2.options[0].text = "Оттава";
            dropdown2.options[1].text = "Ванкувер";
            dropdown2.options[2].text = "Монреаль";
            dropdown2.options[3].text = "Торонто";
        }
        else if (dropdown1.value == 4)
        {
            Indx1 = 5;
            Mess = "В США, в городе ";
            dropdown2.captionText.text = "Хьюстон";

            dropdown2.options[0].text = "Хьюстон";
            dropdown2.options[1].text = "Чикаго";
            dropdown2.options[2].text = "Лос-Анджелес";
            dropdown2.options[3].text = "Нью-Йорк";
        }
        else if (dropdown1.value == 5)
        {
            Indx1 = 6;
            Mess = "В Японии, в городе ";
            dropdown2.captionText.text = "Нагоя";

            dropdown2.options[0].text = "Нагоя";
            dropdown2.options[1].text = "Осака";
            dropdown2.options[2].text = "Йокогама";
            dropdown2.options[3].text = "Токио";
        }
    }

    public void ChangeValue2()
    {
        Debug.Log("Drop2 = " + dropdown2.value);

        if (dropdown2.value == 0)
        {
            Indx2 = 1;
        }
        else if (dropdown2.value == 1)
        {
            Indx2 = 2;
        }
        else if (dropdown2.value == 2)
        {
            Indx2 = 3;
        }
        else if (dropdown2.value == 3)
        {
            Indx2 = 4;
        }

        if (ProvPlace == false)
        {
            int i = -1;

            foreach (Place_Script place in Player_Script.Mass_Player[Player_Script.Score].MassPlacePlayer)
            {
                i++;

                Debug.Log("My.Indx1 = " + Indx1 + "/ My.Indx2 = " + Indx2);
                Debug.Log("Place.Indx1 = " + place.Indx1 + "/ Place.Indx2 = " + place.Indx2);
                if (place.Indx1 == Indx1 && place.Indx2 == Indx2)
                {
                    IndxPlace = i;
                    ProvPlace = true;
                    MyPlace = place;
                    break;
                }

            }
        }

        mycolor = But_ok.colors;

        if (ProvPlace == true)
        {
            mycolor.pressedColor = Color.green;
        }
        else mycolor.pressedColor = Color.red;

        But_ok.colors = mycolor;
    }

    public void But_Back()
    {
        panelEvent.SetActive(false);
        IndxPlace = -1;
    }
}
