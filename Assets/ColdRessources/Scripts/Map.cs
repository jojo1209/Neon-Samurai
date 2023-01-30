using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public bool asPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if( other.tag == "Player") { asPlayer = true; }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") { asPlayer = false; }
    }


}
