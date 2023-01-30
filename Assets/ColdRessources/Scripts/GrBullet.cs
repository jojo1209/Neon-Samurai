using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrBullet : MonoBehaviour
{
    // Start is called before the first frame update

    public int speed;

    public List<GameObject> bullets;
    public GameObject parent;

    private void Start()
    {
        Destroy(this, 5);
    }
    public void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }


    

}
