using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{

    public Map[] maps;

    int player = 0;

    int up = 0;
    int down = 0;
    int left = 0;
    int right = 0;

    int upLeft = 0;
    int downLeft = 0;
    int downRight = 0;
    int upRight = 0;



    void Start()
    {
        Debug.Log(maps[0].name);
        if (maps != null) {
            maps[0].transform.position = new Vector3(0, 0, 0);  player = 0;

            maps[1].transform.position = new Vector3(100, 0, 0); up = 1;
            maps[2].transform.position = new Vector3(-100, 0, 0); down = 2;
            maps[3].transform.position = new Vector3(0, 0, 100); right = 3;
            maps[4].transform.position = new Vector3(0, 0, -100); left = 4;

            maps[5].transform.position = new Vector3(100, 0, 100); upRight = 5;
            maps[6].transform.position = new Vector3(-100, 0, 100); downRight = 6;
            maps[7].transform.position = new Vector3(100, 0, -100); upLeft = 7;
            maps[8].transform.position = new Vector3(-100, 0, -100); downLeft = 8;

            Debug.Log("deplacement de la map Map");
        }
        else { Debug.Log("pas de liste de Map"); }
    }


}
