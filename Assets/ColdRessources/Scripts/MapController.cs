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

    int n=5;

    public int mapY = 100;// taille de la map de haut en bas 


    private void Awake()
    {
        maps=new List<GameObject>();
        if (PrefabMap.Length > 0)
        {
            n = PrefabMap.Length;

                for (int i = 0; i < PrefabMap.Length; i++)
                {
                    GameObject t = Instantiate(PrefabMap[i]);
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
            for(int i=0;i<n;i++)
            {
                maps[i].transform.position = new Vector3(0, i* mapY, 0);
                //maps[i].transform.rotation = Quaternion.Euler(-90, 0, 0);
            }

            down = 0;
            up = n-1;

            //Debug.Log("deplacement de la map Map");
        }
        else { Debug.Log("pas de liste de Map"); }
    }




    public void AvanceMap() 
    {
        foreach (var map in maps) 
        {
            map.transform.position+= Vector3.down* vitesse*Time.deltaTime;
        }

        if (maps[down].transform.position.y < -mapY) 
        {
            maps[down].transform.position = new Vector3(0, mapY, 0) + maps[up].transform.position;
            
            int p = down;

            down += 1;
            if (down==n) 
            { down = 0; }
            up = p;
        }
        
        
    }

    
    private void Update()
    {
        AvanceMap();
    }
}
