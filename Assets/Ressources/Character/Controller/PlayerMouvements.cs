using UnityEngine;

public class PlayerMouvements : MonoBehaviour {
	private void Update()
	{
		if (Time.timeScale == 0) return;
		if (Input.touchCount <= 0) return;
		Touch touch = Input.GetTouch(0);
		if (touch.phase != TouchPhase.Moved) return;
		Vector3 position = transform.position + (Vector3) touch.deltaPosition;;
		position = Camera.main.WorldToViewportPoint(position);
		position = new Vector3(
			Mathf.Clamp(position.x, 0f, 1f),
			Mathf.Clamp(position.y, 0, 1),
			position.z);
		transform.position = Camera.main.ViewportToWorldPoint(position);
	}
}
