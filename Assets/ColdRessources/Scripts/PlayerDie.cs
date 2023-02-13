using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    //IL FAUT METTRE LE GAMEOBJECT "MortPrefab" DANS LE CANVAS POUR QUE CA FONCTIONNE
    public GameObject affichageMort;
    void Start()
    {
    }

    void Update()
    {
        JoueurMort();
    }

    public void JoueurMort()
    {
        affichageMort.SetActive(true);
        Time.timeScale = 0;

    }
}
