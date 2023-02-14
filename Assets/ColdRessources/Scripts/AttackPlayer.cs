using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    public List<Enemy> listEnemie;

    public float coolDown = 1f;
    public bool cooldown;

    void Start()
    {
        cooldown = true;
        Invoke("attaqueRecharger", coolDown);
    }

    private void Update()
    {
        attaque();
    }

    public void attaque() 
    {
    if(cooldown)
        {
            if(listEnemie.Count > 0)
            {
                listEnemie[0].Die();
            }
        }
    }


    void attaqueRecharger()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("a portée du player"+other.name);
        Enemy e = other.gameObject.GetComponent<Enemy>();
        if (e != null)
        { listEnemie.Add(e); }
    }
    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("plus portée du player" + other.name);
        Enemy e = other.gameObject.GetComponent<Enemy>();
        if (e != null)
        { listEnemie.Remove(e); }
    }


}
