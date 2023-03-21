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
		 Vector3 velocity = new Vector3(
			joystick.Horizontal * speed,
			joystick.Vertical * speed,
			myRigidbody.velocity.z);
		
		Vector3 boundingBox = Camera.main.WorldToViewportPoint(myRigidbody.position);
		
		if (boundingBox.x < 0 && velocity.x < 0 || boundingBox.x > 1 && velocity.x > 0)
			velocity.x = 0;
		
		if (boundingBox.y < 0 && velocity.y < 0 || boundingBox.y > 1 && velocity.y > 0)
			velocity.y = 0;

		myRigidbody.velocity = velocity;
	}
}