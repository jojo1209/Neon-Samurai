using UnityEngine;

public class PlayerMouvements : MonoBehaviour {
	public Vector3 moveSpeed = new Vector3(25f, 30f, 0f);

	public void MoveBy(Vector3 move) {
		transform.position += Vector3.Scale(move, moveSpeed);
	}
}
