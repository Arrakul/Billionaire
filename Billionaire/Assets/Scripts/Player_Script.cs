using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Script : MonoBehaviour
{
    //
    public static Player[] Mass_Player;

    public Player player1;
    public Player player2;
    public Player player3;
    public Player player4;

    private string Name;
    private int Money = 5000;

    [HideInInspector]
    public int Reputation = 0;

    private int Chips = 13;

    [HideInInspector]
    public static bool CheckStopMovePlayer = false, CheckDebtPlayer = false;

    public Text name_;
    public Text money;
    public Text chips;
    public Text reputation;

    Transform Point;

    //[HideInInspector]
    //public static Collider other;

    [HideInInspector]
    public static int Score = 0;

    //public GameObject deal;

    // Start is called before the first frame update
    void Start()
    {
        Name = "";
        Chips = 13;
        Score = 0;
        Reputation = 0;
        CheckStopMovePlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        Mass_Player = new Player[] { player1, player2, player3, player4 };

        Name = Mass_Player[Score].Name;
        Money = Mass_Player[Score].Money;
        Chips = Mass_Player[Score].Chips;
        Reputation = Mass_Player[Score].Reputation;
        Point = Mass_Player[Score].Point;

        //deal = new Deal();
        name_.text = Name;
        money.text = Money.ToString();
        chips.text = Chips.ToString();
        reputation.text = Reputation.ToString();

        if (CheckStopMovePlayer == false && Mass_Player[Score].StopMovePlayer > 1 && Mass_Player[Score].SkipMovePolice == 0 && RollTheDice_Scripts.ProvMove == false) CheckStopMove();
        else if (Mass_Player[Score].StopMovePlayer == 0) EventStopMove.massdebtPlayer[Score] = 50;
    }

    public static void CheckDebt()
    {
        if (CheckDebtPlayer == false && (Mass_Player[Score].Money < 0 || Mass_Player[Score].CheckDebt == true))
        {
            Debug.Log("CheckDebt");
            Mass_Player[Score].CheckDebt = true;
            CheckDebtPlayer = true;

            EndGame_Script.UpData();
            EndGame_Script.ProvSetPanel = true;
        }
    }

    void CheckStopMove()
    {
        CheckStopMovePlayer = true;
        EventStopMove.ProvSetPanel = true;
    }

    public static void Buy(bool CheckOnAgree)
    {
        if (CheckOnAgree == true)
        {
            Mass_Player[Score].Money += Mass_Player[Score].other.gameObject.GetComponent<Place_Script>().money;

            //Deal.Status = true;
            Mass_Player[Score].StopMovePlayer = 0;

            Mass_Player[Score].other.gameObject.GetComponent<Place_Script>().status = true;
            Mass_Player[Score].other.gameObject.GetComponent<Place_Script>().TAG = Mass_Player[Score].tag;

            Mass_Player[Score].Chips--;
            if (Mass_Player[Score].Reputation < 4) Mass_Player[Score].Reputation++;

            //Instantiate(Mass_Player[Score].Point, other.transform.position, Quaternion.identity);
            Transform point = Instantiate(Mass_Player[Score].Point, Mass_Player[Score].other.transform.position, Quaternion.identity) as Transform;

            if (Mass_Player[Score].First_Сaptured == true)
            {
                Mass_Player[Score].MassPlacePlayer = new List<Place_Script>();
                Mass_Player[Score].First_Сaptured = false;

                Mass_Player[Score].MassPointPlayer = new List<GameObject>();
            }

            Mass_Player[Score].MassPointPlayer.Add(point.gameObject.gameObject);
            Mass_Player[Score].MassPlacePlayer.Add(Mass_Player[Score].other.gameObject.GetComponent<Place_Script>());
            Debug.Log("Mass = " + Mass_Player[Score].MassPlacePlayer[0].Indx1 + " + " + Mass_Player[Score].MassPlacePlayer[0].Indx2);
        }
        else
        {
            if (Mass_Player[Score].Reputation > -4) Mass_Player[Score].Reputation--;
        }
    }

    //public void Move()
    //{
    //    //Debug.LogError("Ere = " + Mass_Player[Score].other.gameObject.GetComponent<Place_Script>().TAG);
    //    Deal.player = this;
    //    Deal.TagPlace = other.gameObject.GetComponent<Place_Script>().tag;
    //    Deal.Status = other.gameObject.GetComponent<Place_Script>().status;
    //    Deal.Check = false;
    //}
}
