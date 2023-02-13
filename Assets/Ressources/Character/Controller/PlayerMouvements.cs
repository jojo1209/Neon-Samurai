using UnityEngine;

public class PlayerMouvements : MonoBehaviour {
	public Vector3 moveSpeed = new Vector3(25f, 25f, 0f);
    public Vector3 pubic;

    public void MoveBy(Vector3 move) {
        pubic = new Vector3(move.x * moveSpeed.x, move.y * moveSpeed.y, 0f);
        transform.position += pubic;
	}
}
