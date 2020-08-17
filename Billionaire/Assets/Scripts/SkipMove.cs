using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipMove : MonoBehaviour
{

    public GameObject panel;
    public GameObject Mycamera;
    private List<GameObject> Mass_Player;

    private bool prov = true;

    // Start is called before the first frame update
    void Start()
    {
        prov = true;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void But_SkipMove()
    {
        if (prov == true)
        {
            panel.SetActive(true);
            prov = false;
        }
    }

    public void But_Back()
    {
        if(prov == false)
        {
            panel.SetActive(false);
            prov = true;
        }
    }

    public void But_OK()
    {
        Mass_Player = RollTheDice_Scripts.Mass_Player;

        //=====================================================================
        if (RollTheDice_Scripts.ProvMove == false)
        {
            if (RollTheDice_Scripts.Score == 4) RollTheDice_Scripts.Score = 1;
            else RollTheDice_Scripts.Score++;

            if (Player_Script.Mass_Player[Player_Script.Score].SkipMovePolice == 0)
            {
                Player_Script.Mass_Player[Player_Script.Score].StopMovePlayer++;
            }
        }
        else RollTheDice_Scripts.ProvMove = false;

        if (Player_Script.Mass_Player[Player_Script.Score].CheckDebt == true)
        {
            EndGame_Script.massdebtPlayer[Player_Script.Score][1]--;
        }

        foreach (GameObject player in Mass_Player)
        {
            if (RollTheDice_Scripts.Score == 1 && player.tag == "Player2")
            {
                if (Player_Script.Mass_Player[Player_Script.Score].SkipMovePolice != 0)
                {
                    Player_Script.Mass_Player[Player_Script.Score].SkipMovePolice -= 1;
                }

                var position = player.transform.position;
                position.z = -100;
                Mycamera.transform.position = position;
                Player_Script.Score = 1;
            }

            if (RollTheDice_Scripts.Score == 2 && player.tag == "Player3")
            {
                if (Player_Script.Mass_Player[Player_Script.Score].SkipMovePolice != 0)
                {
                    Player_Script.Mass_Player[Player_Script.Score].SkipMovePolice -= 1;
                }

                var position = player.transform.position;
                position.z = -100;
                Mycamera.transform.position = position;
                Player_Script.Score = 2;
            }

            if (RollTheDice_Scripts.Score == 3 && player.tag == "Player4")
            {
                if (Player_Script.Mass_Player[Player_Script.Score].SkipMovePolice != 0)
                {
                    Player_Script.Mass_Player[Player_Script.Score].SkipMovePolice -= 1;
                }

                var position = player.transform.position;
                position.z = -100;
                Mycamera.transform.position = position;
                Player_Script.Score = 3;
            }

            if (RollTheDice_Scripts.Score == 4 && player.tag == "Player1")
            {
                if (Player_Script.Mass_Player[Player_Script.Score].SkipMovePolice != 0)
                {
                    Player_Script.Mass_Player[Player_Script.Score].SkipMovePolice -= 1;
                }

                var position = player.transform.position;
                position.z = -100;
                Mycamera.transform.position = position;
                Player_Script.Score = 0;
            }

            if (Player_Script.Mass_Player[Player_Script.Score].CheckDebt == true || Player_Script.Mass_Player[Player_Script.Score].Money < 0)
            {
                EndGame_Script.panelDeptClose.SetActive(true);
                EndGame_Script.UpData();
            }
            else EndGame_Script.panelDeptClose.SetActive(false);

            Player_Script.CheckStopMovePlayer = false;
            Player_Script.CheckDebtPlayer = false;
            RollTheDice_Scripts.Prov = true;
            panel.SetActive(false);
            Deal.Check = false;
            prov = true;
        }
    }
}
