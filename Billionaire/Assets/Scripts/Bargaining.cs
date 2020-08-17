using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bargaining : MonoBehaviour
{

    public GameObject Panel;
    public Text TextNumberRand;
    public Text TextSign;
    public Text TextNumber;
    public GameObject panel;

    //[HideInInspector]
    //public static Player_Script player;

    [HideInInspector]
    public int Number, NumberRan;
    private int Quantity;

    // Start is called before the first frame update
    void Start()
    {
        Number = 6;
        NumberRan = 0;
        Quantity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        TextNumber.text = Number.ToString();
        TextNumberRand.text = NumberRan.ToString();

        if (NumberRan <= Number)
        {
            TextSign.text = "<";
            panel.GetComponent<Image>().color = Color.red;
        }
        else
        {
            TextSign.text = ">";
            panel.GetComponent<Image>().color = Color.green;
        }
    }

    public void But_OK()
    {
        Panel.SetActive(false);

        if (NumberRan > Number)
        {
            //player.Buy(true);
            Player_Script.Buy(true);
        }
        else Player_Script.Buy(false);//player.Buy(false);

        Number = 6;
        NumberRan = 0;
        Quantity = 0;
    }

    public void But_RandNumber()
    {
        if (Quantity < 2)
        {
            System.Random rnd = new System.Random();
            NumberRan += rnd.Next(1, 7);

            if (Quantity == 0) NumberRan += Player_Script.Mass_Player[Player_Script.Score].Reputation;

            Quantity++;
        }
    }
}
