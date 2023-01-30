using UnityEngine;

public class PlayerMouvements : MonoBehaviour {
	public float moveSpeed = 0.7f;

	public void MoveBy(Vector3 move) {
		transform.position += move * moveSpeed;
	}
}
