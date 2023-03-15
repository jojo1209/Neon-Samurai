using UnityEngine;

public class PlayerMouvements : MonoBehaviour {
	public Vector3 moveSpeed = new Vector3(25f, 30f, 0f);

	public void MoveBy(Vector3 move) {
		transform.position += Vector3.Scale(move, moveSpeed);
	}

	private void Update()
	{
		if (Time.timeScale == 0) return;
		if (Input.touchCount <= 0) return;
		Touch touch = Input.GetTouch(0);
		if (touch.phase != TouchPhase.Moved) return;
		Vector3 touchGap = touch.deltaPosition;
		transform.position += touchGap;
	}
}
