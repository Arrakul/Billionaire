using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceBusSym : MonoBehaviour
{
    public GameObject panelBusSym;

    [HideInInspector]
    public static bool ProvSetPanel = false;

    // Start is called before the first frame update
    void Start()
    {
        ProvSetPanel = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ProvSetPanel == true)
        {
            panelBusSym.SetActive(true);
            ProvSetPanel = false;
        }
    }

    public void But_Ok()
    {
        foreach(Player player in Player_Script.Mass_Player)
        {
            Player_Script.Mass_Player[Player_Script.Score].Money += 200;
            player.Money -= 200;

            if (player.Reputation < 4) player.Reputation++;
        }

        panelBusSym.SetActive(false);
    }
}
