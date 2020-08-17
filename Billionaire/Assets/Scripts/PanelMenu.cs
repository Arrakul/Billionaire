using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PanelMenu : MonoBehaviour
{
    public static int MoneyBank, MoneyFond;

    public Text TextMoneyBank;
    public Text TextMoneyFond;

    public GameObject panelMenu;

    // Start is called before the first frame update
    void Start()
    {
        MoneyBank = 5000;
        MoneyFond = 0;
    }

    // Update is called once per frame
    void Update()
    {
        TextMoneyBank.text = MoneyBank.ToString();
        TextMoneyFond.text = MoneyFond.ToString();
    }

    public void But_Exit()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("MenuScene");
    }

    public void But_Back()
    {
        panelMenu.SetActive(false);
    }

    public void But_Menu()
    {
        if (panelMenu.activeSelf == false) panelMenu.SetActive(true);
        else panelMenu.SetActive(false);
    }

    public void But_PlaceSaleBank()
    {
        if (Player_Script.Mass_Player[Player_Script.Score].Money < 100)
        {
            PanelSalePlace.ProvSetPanel = true;
            PanelSalePlace.ProvBank = true;
            panelMenu.SetActive(false);
        }
    }
}
