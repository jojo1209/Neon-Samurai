using UnityEngine;

public class PlayerController: MonoBehaviour
{
	public FloatingJoystick  joystick;
	private Rigidbody myRigidbody;
	public float speed = 800f;

	private void Start()
	{
		myRigidbody = GetComponent<Rigidbody>();
		myRigidbody.isKinematic = false;
	}
	
	private void Update()
	{
		myRigidbody.velocity = new Vector3(
			joystick.Horizontal * speed,
			joystick.Vertical * speed,
			myRigidbody.velocity.z);
	}
}