using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{

    public void Retour() 
    {
        SceneManager.LoadScene("MainMenu");
    }
}
