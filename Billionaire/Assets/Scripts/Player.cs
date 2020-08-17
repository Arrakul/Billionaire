using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string Name = "Red";
    public int Money = 0, MaxMoney = 5000;
    public int Reputation = 0;

    public int Chips = 13;

    [HideInInspector]
    public bool First_Move = true, First_Сaptured = true, CheckDebt = false;

    public Transform Point;
    public Transform CenterPoint;

    [HideInInspector]
    public static bool CheckTrigger = false; 

    [HideInInspector]
    public List<Place_Script> MassPlacePlayer;

    [HideInInspector]
    public List<GameObject> MassPointPlayer;

    [HideInInspector]
    public int StopMovePlayer = 0, SkipMovePolice = 0;

    [HideInInspector]
    public Collider other;

    void OnTriggerEnter(Collider other)
    {
        this.other = other;

        if (other.tag == "Place")
        {
            Debug.Log("Conct = " + other.gameObject.GetComponent<Place_Script>().Indx1);

            if (other.gameObject.GetComponent<Place_Script>().status == false && Chips > 0)
            {
                //Player_Script.other = other;
                //(new Player_Script()).Move();
                Deal.UpdateDataInDeal();
            }
            else if (other.gameObject.GetComponent<Place_Script>().status == true && other.gameObject.GetComponent<Place_Script>().TAG != this.tag)
            {
                foreach(Player player in Player_Script.Mass_Player)
                {
                    if (player.tag == other.gameObject.GetComponent<Place_Script>().TAG)
                    {
                        player.Money += other.gameObject.GetComponent<Place_Script>().money + (player.Reputation * 100);
                        this.Money -= other.gameObject.GetComponent<Place_Script>().money + (player.Reputation * 100);
                    }
                }
            }
            else if (other.gameObject.GetComponent<Place_Script>().status == true && other.gameObject.GetComponent<Place_Script>().TAG == this.tag)
            {
                if (other.gameObject.GetComponent<Place_Script>().CenterPlacePoint == true)
                {
                    this.Money += 1000;
                    if (this.Reputation < 4) this.Reputation += 1;
                }
                else
                {
                    PanelEvent.ProvSetPanel = true;
                }
            }
        }
        else if (other.tag == "PlaceCountry")
        {
            Debug.Log("Country");
            PlaceCountry.ProvSetPanel = true;
        }
        else if (other.tag == "PlaceAd")
        {
            Debug.Log("Ad");
            PlaceAd.ProvSetPanel = true;
        }
        else if (other.tag == "PlaceBusSym")
        {
            Debug.Log("PlaceBusSym");
            PlaceBusSym.ProvSetPanel = true;
        }
        else if (other.tag == "PlaceFond")
        {
            Debug.Log("PlaceFond");
            PlaceFond.ProvSetPanel = true;
        }
        else if (other.tag == "PlaceCasino")
        {
            Debug.Log("PlaceCasino");
            PlaceCasino.ProvSetPanel = true;
        }
        else if (other.tag == "PlacePolice")
        {
            Debug.Log("PlacePolice");
            PlacePolice.ProvSetPanel = true;
        }

        Player_Script.CheckDebt();

        if(MaxMoney < Money)
        {
            MaxMoney = Money;
        }
    }
}
