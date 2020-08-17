using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollTheDice_Scripts : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    public GameObject panelRoll;
    public GameObject PanelFirstMove;
    public GameObject Camera;

    public Text Ran_text;

    private int Rand_Num;
    public static bool Prov = true, ProvMove = false;
    public static int Score = 0;
    public static List<GameObject> Mass_Player;

    // Start is called before the first frame update
    void Start()
    {
        Rand_Num = 0;
        Prov = true;
        ProvMove = false;
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Mass_Player = new List<GameObject>() { player1, player2, player3, player4};
    }

    public void But_RollDice()
    {
        if (Player_Script.Mass_Player[Player_Script.Score].SkipMovePolice == 0)
        {
            //Debug.Log("First move = " + Player_Script.Mass_Player[Player_Script.Score].First_Move);
            if (Player_Script.Mass_Player[Player_Script.Score].First_Move == false)
            {
                PanelFirstMove.SetActive(true);
                Player_Script.Mass_Player[Player_Script.Score].First_Move = true;
            }
            else
            {
                System.Random rnd = new System.Random();
                if (Prov)
                {
                    Player_Script.Mass_Player[Player_Script.Score].StopMovePlayer = 0;
                    panelRoll.SetActive(true);
                    Rand_Num = rnd.Next(1, 7) + rnd.Next(1, 7);
                    Ran_text.text = Rand_Num.ToString();
                    Prov = false;
                }
            }
        }
    }

    public void MovePlayer(GameObject player)
    {
        for (int i = 0; i < Rand_Num; i++)
        {
            if (player.transform.position.x < 200 && player.transform.position.x > -160 && player.transform.position.y < -155 && player.transform.position.y > -200)
            {
                Debug.Log(" k = 2");

                var position = player.transform.position;
                position.x -= 40f;
                player.transform.position = position;

                position.z = -100;
                Camera.transform.position = position;
            }
            else if (player.transform.position.y > -200 && player.transform.position.y < 155 && player.transform.position.x > -200 && player.transform.position.x < -160)
            {
                Debug.Log(" k = 3");

                var position = player.transform.position;
                position.y += 45f;
                player.transform.position = position;

                position.z = -100;
                Camera.transform.position = position;
            }
            else if (player.transform.position.x > -200 && player.transform.position.x < 160 && player.transform.position.y < 200 && player.transform.position.y > 155)
            {
                Debug.Log(" k = 4");

                var position = player.transform.position;
                position.x += 40f;
                player.transform.position = position;

                position.z = -100;
                Camera.transform.position = position;
            }
            else if (player.transform.position.y < 200 && player.transform.position.y > -155 && player.transform.position.x > 160 && player.transform.position.x < 200)
            {
                Debug.Log(" k = 1");

                var position = player.transform.position;
                position.y -= 45f;
                player.transform.position = position;

                position.z = -100;
                Camera.transform.position = position;
            }
        }
    }

    public void But_OK()
    {
        panelRoll.SetActive(false);

        if (Score != 4) Score++;
        else Score = 1;
        ProvMove = true;

        foreach (GameObject player in Mass_Player)
        {
            if (Score == 1 && player.tag == "Player1")
            {
                MovePlayer(player);
            }
            else if (Score == 2 && player.tag == "Player2")
            {
                MovePlayer(player);
            }
            else if (Score == 3 && player.tag == "Player3")
            {
                MovePlayer(player);
            }
            else if (Score == 4 && player.tag == "Player4")
            {
                MovePlayer(player);
            }
        }
    }
}
