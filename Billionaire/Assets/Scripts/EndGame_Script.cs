using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using System.IO;

public class EndGame_Script : MonoBehaviour
{
    public GameObject panelDebt;
    public Text textmess;

    public static GameObject panelDeptClose;

    //==================================

    public GameObject panelInterface;
    public GameObject panelEndGame;
    public Text TextPointRed;
    public Text TextPointBlue;
    public Text TextPointGreen;
    public Text TextPointYellow;

    public Text TextPlaceRed;
    public Text TextPlaceBlue;
    public Text TextPlaceGreen;
    public Text TextPlaceYellow;

    [HideInInspector]
    public static bool ProvSetPanel = false, ProvPanelEnd = false;

    public static int[][] massdebtPlayer;

    // Start is called before the first frame update
    void Start()
    {
        ProvPanelEnd = false;
        ProvSetPanel = false;

        massdebtPlayer = new int[4][];
        massdebtPlayer[0] = new int[2] { 0, 3 };
        massdebtPlayer[1] = new int[2] { 0, 3 };
        massdebtPlayer[2] = new int[2] { 0, 3 };
        massdebtPlayer[3] = new int[2] { 0, 3 };
    }

    // Update is called once per frame
    void Update()
    {
        panelDeptClose = panelDebt;

        if (ProvSetPanel == true)
        {
            panelDebt.SetActive(true);
            ProvSetPanel = false;
        }

        if(massdebtPlayer[Player_Script.Score][1] < 0)
        {
            panelInterface.SetActive(false);
            panelDebt.SetActive(false);
            panelEndGame.SetActive(true);

            if (ProvPanelEnd == false) EndGame();
        }

        textmess.text = "Вы должны банку " + (-massdebtPlayer[Player_Script.Score][0]) + ", у вас " + massdebtPlayer[Player_Script.Score][1];
        if (massdebtPlayer[Player_Script.Score][1] == 1) textmess.text += " ход чтобы отдать!";
        else if (massdebtPlayer[Player_Script.Score][1] < 5) textmess.text += " хода чтобы отдать!";
        else textmess.text += " ходов чтобы отдать!";
    }

    public void EndGame()
    {
        ProvPanelEnd = true;
        int i = 4;
        var mass = new List<int>();

        int redpoint = Player_Script.Mass_Player[0].MaxMoney * ((13 - Player_Script.Mass_Player[0].Chips) + 1);
        int bluepoint = Player_Script.Mass_Player[1].MaxMoney * ((13 - Player_Script.Mass_Player[1].Chips) + 1);
        int greenpoint = Player_Script.Mass_Player[2].MaxMoney * ((13 - Player_Script.Mass_Player[2].Chips) + 1);
        int yellownpoint = Player_Script.Mass_Player[3].MaxMoney * ((13 - Player_Script.Mass_Player[3].Chips) + 1);

        mass.Add(redpoint);
        mass.Add(bluepoint);
        mass.Add(greenpoint);
        mass.Add(yellownpoint);
        mass.Sort();

        TextPointRed.text = redpoint.ToString();
        TextPointBlue.text = bluepoint.ToString();
        TextPointGreen.text = greenpoint.ToString();
        TextPointYellow.text = yellownpoint.ToString();

        foreach(var item in mass)
        {
            if (item == redpoint) TextPlaceRed.text = i.ToString();
            if (item == bluepoint) TextPlaceBlue.text = i.ToString();
            if (item == greenpoint) TextPlaceGreen.text = i.ToString();
            if (item == yellownpoint) TextPlaceYellow.text = i.ToString();

            i--;
        }

    }

    public static void UpData()
    {
        massdebtPlayer[Player_Script.Score][0] += Player_Script.Mass_Player[Player_Script.Score].Money;
        PanelMenu.MoneyBank += Player_Script.Mass_Player[Player_Script.Score].Money;
        Player_Script.Mass_Player[Player_Script.Score].Money = 0;
    }

    public void But_OK()
    {
        int money = 0;

        if(Player_Script.Mass_Player[Player_Script.Score].Money > 0)
        {
            money = Player_Script.Mass_Player[Player_Script.Score].Money + massdebtPlayer[Player_Script.Score][0];

            if (money >= 0)
            {
                Player_Script.Mass_Player[Player_Script.Score].CheckDebt = false;
                Player_Script.Mass_Player[Player_Script.Score].Money = money;
                PanelMenu.MoneyBank -= massdebtPlayer[Player_Script.Score][0];

                massdebtPlayer[Player_Script.Score][0] = 0;
                massdebtPlayer[Player_Script.Score][1] = 3;

                panelDebt.SetActive(false);
            }
            else
            {
                PanelMenu.MoneyBank += Player_Script.Mass_Player[Player_Script.Score].Money;
                Player_Script.Mass_Player[Player_Script.Score].Money = 0;
                massdebtPlayer[Player_Script.Score][0] = money;
                massdebtPlayer[Player_Script.Score][1]++;
            }
        }
    }

    public void But_Exit()
    {
        string str;
        string[] mass;

        if (!Directory.Exists(Application.dataPath + "/Resources/TextFiles"))
            Directory.CreateDirectory(Application.dataPath + "/Resources/TextFiles");

        if (!File.Exists((Application.dataPath + "/Resources/TextFiles/RecordFile.txt")))
        {
            //File.Create(Application.dataPath + "/Resources/TextFiles/RecordFile.txt");
            //Debug.Log("File Create!");

            FileStream fileStream = new FileStream(Application.dataPath + "/Resources/TextFiles/RecordFile.txt", FileMode.Create);

            using (var textfile = new StreamWriter(fileStream))
            {
                textfile.WriteLine("20000 ");
                textfile.WriteLine("5000 ");
                textfile.WriteLine("5000 ");
                textfile.WriteLine("5000 ");
                textfile.WriteLine("5000");

                Debug.Log("Start File Save!");
            }

            fileStream.Close();
        }

        FileStream fileStream2 = new FileStream(Application.dataPath + "/Resources/TextFiles/RecordFile.txt", FileMode.Open);
        using (var textfile = new StreamReader(fileStream2))
        {
            str = textfile.ReadToEnd();
            mass = str.Split(' ');
        }
        fileStream2.Close();


        int sumfile = System.Convert.ToInt32(mass[0]);
        int sum = System.Convert.ToInt32(TextPointRed.text) + System.Convert.ToInt32(TextPointBlue.text) +
                      System.Convert.ToInt32(TextPointGreen.text) + System.Convert.ToInt32(TextPointYellow.text);


        if (sumfile < sum)
        {

            mass[0] = sum.ToString() + " ";
            mass[1] = TextPointRed.text + " ";
            mass[2] = TextPointBlue.text + " ";
            mass[3] = TextPointGreen.text + " ";
            mass[4] = TextPointYellow.text;

            fileStream2 = new FileStream(Application.dataPath + "/Resources/TextFiles/RecordFile.txt", FileMode.Open);
            using (var textfile = new StreamWriter(fileStream2))
            {
                foreach (var s in mass)
                {
                    textfile.WriteLine(s);
                }

                Debug.Log("File Save!");
            }

            fileStream2.Close();
        }

        SceneManager.LoadScene("MenuScene");
    }
}
