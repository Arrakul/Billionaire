using UnityEngine.UI;
using UnityEngine;

public class EventStopMove : MonoBehaviour
{

    public GameObject panelStopMove;
    public Text textmess;

    [HideInInspector]
    public static bool ProvSetPanel = false;

    public static int[] massdebtPlayer;

    // Start is called before the first frame update
    void Start()
    {
        ProvSetPanel = false;

        massdebtPlayer = new int[4];
        massdebtPlayer[0] = 50;
        massdebtPlayer[1] = 50;
        massdebtPlayer[2] = 50;
        massdebtPlayer[3] = 50;
    }

    // Update is called once per frame
    void Update()
    {
        if (ProvSetPanel == true)
        {
            panelStopMove.SetActive(true);
            ProvSetPanel = false;
        }

        textmess.text = "Вы потеряли " + (massdebtPlayer[Player_Script.Score]*2) + ", за простой!";
    }

    public void But_DebtPlayer()
    {
        massdebtPlayer[Player_Script.Score] *= 2;

        PanelMenu.MoneyBank += massdebtPlayer[Player_Script.Score];
        Player_Script.Mass_Player[Player_Script.Score].Money -= massdebtPlayer[Player_Script.Score];

        panelStopMove.SetActive(false);
    }

}
