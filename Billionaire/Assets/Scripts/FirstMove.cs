using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstMove : MonoBehaviour
{

    public GameObject Panel;
    public GameObject ColorPanel;
    public Text TextCountry;
    public Text TextCity;
    public Button BRanCountry;
    public Button BRanCity;
    public Button BOK;

    string textcountry = "None";
    string textcity = "None";
    bool ProvContry = false;
    bool ProvCity = false;
    int IndxCountry, IndxCity, IndxCityMassPlace;

    public static string[][] Mass;

    ColorBlock mycolor;

    // Start is called before the first frame update
    void Start()
    {
        textcountry = "None";
        textcity = "None";
        ProvContry = false;
        ProvCity = false;
        IndxCountry = 0;
        IndxCity = 0;
        IndxCityMassPlace = 0;

        Mass = new string[6][];
        Mass[0] = new string[4] { "Москва", "Питер", "Казань", "Новосибирск"};
        Mass[1] = new string[4] { "Берлин", "Париж", "Рим", "Вена" };
        Mass[2] = new string[4] { "Пекин", "Шанхай", "Тяньцзинь", "Шеньян" };
        Mass[3] = new string[4] { "Оттава", "Ванкувер", "Монреаль", "Торонто" };
        Mass[4] = new string[4] { "Хьюстон", "Чикаго", "Лос-Анджелес", "Нью-Йорк" };
        Mass[5] = new string[4] { "Нагоя", "Осака", "Йокогама", "Токио" };
    }

    // Update is called once per frame
    void Update()
    {
        TextCountry.text = textcountry;
        TextCity.text = textcity;

        if (ProvContry == true) BRanCountry.GetComponent<Image>().color = Color.green;
        else BRanCountry.GetComponent<Image>().color = Color.white;

        if (ProvCity == true)
        {
            BRanCity.GetComponent<Image>().color = Color.green;
            ColorPanel.GetComponent<Image>().color = Color.green;

            mycolor = BOK.GetComponent<Button>().colors;
            mycolor.pressedColor = Color.green;
            BOK.GetComponent<Button>().colors = mycolor;
        }
        else
        {
            //mycolor = BOK.GetComponent<Button>().colors;
            //mycolor.pressedColor = Color.red;
            //BOK.GetComponent<Button>().colors = mycolor;

            //mycolor = BRanCity.GetComponent<Button>().colors;
            //mycolor.pressedColor = Color.red;
            //BRanCity.GetComponent<Button>().colors = mycolor;

            ColorPanel.GetComponent<Image>().color = Color.red;
            BRanCity.GetComponent<Image>().color = Color.white;
        }
    }

    public void But_Ok()
    {
        if (ProvCity == true)
        {
            foreach(Place_Script place in MassPlace_Script.MassPlace)
            {
                if (place.Indx1 == IndxCountry+1 && place.Indx2 == IndxCity+1)
                {
                    Instantiate(Player_Script.Mass_Player[Player_Script.Score].CenterPoint, place.transform.position, Quaternion.identity);
                    place.status = true;
                    place.TAG = Player_Script.Mass_Player[Player_Script.Score].tag;
                    place.CenterPlacePoint = true;
                }
            }

            textcity = "";
            textcountry = "";
            ProvCity = false;
            ProvContry = false;
            Panel.SetActive(false);
        }
    }

    int ind = 0;
    public void But_RanCity()
    {

        if (ProvContry == true && ProvCity == false)
        {
            System.Random rnd = new System.Random();
            IndxCity = rnd.Next(0, 4);

            if (MassPlace_Script.MassPlace[IndxCity + IndxCityMassPlace].status == false)
            {
                textcity = Mass[IndxCountry][IndxCity];
                ProvCity = true;
                ind = 0;
            }

            ind++;

            if (ind >= 4)
            {
                ProvContry = false;
                ind = 0;
            }
        }
    }

    public void But_RanCountry()
    {
        if (ProvContry == false)
        {
            System.Random rnd = new System.Random();
            IndxCountry = rnd.Next(0, 6);

            switch (IndxCountry)
            {
                case 0:
                    textcountry = "Россия";
                    IndxCityMassPlace = 0;
                    break;
                case 1:
                    textcountry = "ЕС";
                    IndxCityMassPlace = 4;
                    break;
                case 2:
                    textcountry = "Китай";
                    IndxCityMassPlace = 8;
                    break;
                case 3:
                    textcountry = "Канада";
                    IndxCityMassPlace = 12;
                    break;
                case 4:
                    textcountry = "США";
                    IndxCityMassPlace = 16;
                    break;
                case 5:
                    textcountry = "Япония";
                    IndxCityMassPlace = 20;
                    break;
            }

            ProvContry = true;
        }
    }
}
