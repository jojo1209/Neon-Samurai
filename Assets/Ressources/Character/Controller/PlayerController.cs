using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
public FloatingJoystick joystick;
public Rigidbody myRigidbody;
public float speed = 20f;




    // Update is called once per frame
    void Update()
    {
        myRigidbody.velocity = new Vector3(joystick.Horizontal * speed, joystick.Vertical * speed, myRigidbody.velocity.z);

        
    }
}




// if (Input.touchCount > 0)
//         {
//             Touch touch = Input.GetTouch(0);
//             Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
//             touchPosition.z = 0f;
//             transform.position = touchPosition;
//         }