using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public GameObject[] PrefabMap;

    private List<GameObject> maps;


    
    public float vitesse;

    int center=0;
    int up = 0;
    int down = 0;

    int mapY = 100;// taille de la map de haut en bas 


    private void Awake()
    {
        maps=new List<GameObject>();
        if (PrefabMap.Length > 0)
        {

                for (int i = 0; i < 3; i++)
                {

                    int n =Random.Range(0, PrefabMap.Length);
                    GameObject t = Instantiate(PrefabMap[n]);
                    maps.Add(t);
                }
        }
        else 
        {
            Debug.Log("pas de prefab de map");
        }
    }

    void Start()
    {
        Debug.Log(maps[0].name);
        if (maps != null) {
            for(int i=0;i<3;i++)
            {
                maps[i].transform.position = new Vector3(0, i* mapY, 0);
                maps[i].transform.rotation = Quaternion.Euler(90, 0, 0);
            }
            down = 0;
            center = 1;
            up = 2;

            //Debug.Log("deplacement de la map Map");
        }
        else { Debug.Log("pas de liste de Map"); }
    }




    public void AvanceMap() 
    {
        foreach (var map in maps) 
        {
            map.transform.position+= Vector3.down* vitesse;
        }

        if (maps[down].transform.position.y < -mapY) 
        {
            maps[down].transform.position = new Vector3(0, mapY, 0) + maps[up].transform.position;
            int p = down;
            down = center;
            center = up;
            up = p;
        }
        

    }

    
    private void Update()
    {
        AvanceMap();
    }
}
