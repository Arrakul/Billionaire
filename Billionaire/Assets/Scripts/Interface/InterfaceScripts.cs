using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using System.IO;

public class InterfaceScripts : MonoBehaviour
{
    public GameObject panelMessage;
    public GameObject panelRecord;

    public Text textBestRecord;
    public Text textRedRecord;
    public Text textBlueRecord;
    public Text textGreenRecord;
    public Text textYellowRecord;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void But_GameRules()
    {
        if (!panelMessage.activeSelf)
        {
            panelMessage.SetActive(true);
        }
        else panelMessage.SetActive(false);
    }

    public void But_ClosePanelMessage()
    {
        if (!panelMessage.activeSelf)
        {
            panelMessage.SetActive(true);
        }
        else panelMessage.SetActive(false);
    }

    public void But_Record()
    {
        if (!panelRecord.activeSelf)
        {
            panelRecord.SetActive(true);

            if (!Directory.Exists(Application.dataPath + "/Resources/TextFiles"))
                Directory.CreateDirectory(Application.dataPath + "/Resources/TextFiles");

            if (!File.Exists((Application.dataPath + "/Resources/TextFiles/RecordFile.txt")))
            {

                FileStream fileStream = new FileStream(Application.dataPath + "/Resources/TextFiles/RecordFile.txt", FileMode.Create);

                using (var textfile = new StreamWriter(fileStream))
                {
                    textfile.WriteLine("20000 ");
                    textfile.WriteLine("5000 ");
                    textfile.WriteLine("5000 ");
                    textfile.WriteLine("5000 ");
                    textfile.WriteLine("5000");


                    textBestRecord.text = "Лучшая игра: 20000 очков!";
                    textRedRecord.text = "Red: 5000 очков!";
                    textBlueRecord.text = "Blue: 5000 очков!";
                    textGreenRecord.text = "Green: 5000 очков!";
                    textYellowRecord.text = "Yellow: 5000 очков!";

                    Debug.Log("Start File Save!");
                }

                fileStream.Close();
            }
            else
            {
                string str;
                string[] mass;
                int num;

                FileStream fileStream = new FileStream(Application.dataPath + "/Resources/TextFiles/RecordFile.txt", FileMode.Open);

                using (var textfile = new StreamReader(fileStream))
                {
                    str = textfile.ReadToEnd();
                    mass = str.Split(' ');
                }

                textBestRecord.text = "Лучшая игра: " + mass[0] + " очков!";

                num = int.Parse(mass[1]);
                textRedRecord.text = "Red: " + num + " очков!";

                num = int.Parse(mass[2]);
                textBlueRecord.text = "Blue: " + num + " очков!";

                num = int.Parse(mass[3]);
                textGreenRecord.text = "Green: " + num + " очков!";

                num = int.Parse(mass[4]);
                textYellowRecord.text = "Yellow: " + num + " очков!";
            }
        }
        else panelRecord.SetActive(false);
    }

    public void But_Start()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void But_Exit()
    {
        Application.Quit();
    }
}
