using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed = 0.7f;

	public void MoveBy(Vector3 move) {
		transform.position += move * moveSpeed;
	}
}
