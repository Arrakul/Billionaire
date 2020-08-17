using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassPlace_Script : MonoBehaviour
{

    public Place_Script place1_1;
    public Place_Script place1_2;
    public Place_Script place1_3;
    public Place_Script place1_4;

    public Place_Script place2_1;
    public Place_Script place2_2;
    public Place_Script place2_3;
    public Place_Script place2_4;

    public Place_Script place3_1;
    public Place_Script place3_2;
    public Place_Script place3_3;
    public Place_Script place3_4;

    public Place_Script place4_1;
    public Place_Script place4_2;
    public Place_Script place4_3;
    public Place_Script place4_4;

    public Place_Script place5_1;
    public Place_Script place5_2;
    public Place_Script place5_3;
    public Place_Script place5_4;

    public Place_Script place6_1;
    public Place_Script place6_2;
    public Place_Script place6_3;
    public Place_Script place6_4;

    [HideInInspector]
    public static Place_Script[] MassPlace;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MassPlace = new Place_Script[] 
        {
        place1_1, place1_2, place1_3, place1_4,
        place2_1, place2_2, place2_3, place2_4,
        place3_1, place3_2, place3_3, place3_4,
        place4_1, place4_2, place4_3, place4_4,
        place5_1, place5_2, place5_3, place5_4,
        place6_1, place6_2, place6_3, place6_4
        };
    }
}
