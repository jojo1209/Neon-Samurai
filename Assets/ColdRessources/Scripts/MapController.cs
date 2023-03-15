using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public List<MapBiome> mapBiomes;

    private List<GameObject> bats;

    int indexBiome = 0;
    public float vitesse;

    public int batY = 16;
    public int scale=1;



    int batDown = 0;
    int batUp = 0;
    int centreBat;

    int repetition;


    int batn = 4;
    int batnn = 4;

    public Transform mapParent;

    private bool changeBiom = false;

    private void Awake()
    {
        batY = batY * scale;
        bats = new List<GameObject>();


        foreach (GameObject m in mapBiomes[indexBiome].BatBiome)
        {
            GameObject b = Instantiate(m, mapParent);
            b.transform.localScale=b.transform.localScale* scale;
            bats.Add(b); 
        }
        batnn = batn = mapBiomes[indexBiome].BatBiome.Length;

        repetition = mapBiomes[indexBiome].repetition;


    }

    void Start()
    {



        for (int i = 0; i < batn; i++)
        {
            bats[i].transform.localPosition = new Vector3(720, i * batY, 0);
        }
        batDown = 0;
        batUp = batn - 1;


    }

    void changementBiom()
    {
        changeBiom = true;
        indexBiome++;
        if(indexBiome >= mapBiomes.Count) { indexBiome = 0; }

        foreach (GameObject m in mapBiomes[indexBiome].BatBiome)
        {
            GameObject b = Instantiate(m, mapParent);
            b.transform.localScale = b.transform.localScale * scale;
            bats.Add(b);
           
        }
        for (int i = batUp + 1; i < bats.Count; i++)
        {
            bats[i].transform.localPosition = new Vector3(720, bats[batUp].transform.localPosition.y + (i - batUp) * batY, 0);
        }
        batn = mapBiomes[indexBiome].BatBiome.Length;
        batnn = bats.Count;
        repetition = mapBiomes[indexBiome].repetition;
    }



    public void AvanceMap()
    {

        foreach (var bat in bats)
        {
            bat.transform.localPosition += Vector3.down * vitesse * Time.deltaTime * scale*Time.timeScale;
        }


        if (bats[batDown].transform.localPosition.y < -batY)
        {

            if (changeBiom)
            {
                GameObject g = bats[batDown];
                bats.RemoveAt(batDown);

                Destroy(g);

                batnn -= 1;
                if (batnn <= batn)
                { changeBiom = false; }
            }
            else
            {

                bats[batDown].transform.localPosition = new Vector3(0, batY, 0) + bats[batUp].transform.localPosition;
                int p = batDown;

                batUp = p;
                batDown += 1;

                if (batDown == batn)
                {
                    batDown = 0;
                    repetition -= 1;
                    if (repetition <= 0)
                    {
                        changementBiom();
                    }
                }
            }

        }



    }


    private void Update()
    {
        AvanceMap();
    }
}





