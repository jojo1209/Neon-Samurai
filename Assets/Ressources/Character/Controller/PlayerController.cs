using UnityEngine;

public class PlayerController: MonoBehaviour
{
	public FixedJoystick joystick;
	public Rigidbody myRigidbody;
	public float speed = 20f;

	private void Update()
	{
		myRigidbody.velocity = new Vector3(
			joystick.Horizontal * speed,
			joystick.Vertical * speed,
			myRigidbody.velocity.z);
	}
}