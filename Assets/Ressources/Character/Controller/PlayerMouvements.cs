using UnityEngine;

public class PlayerMouvements : MonoBehaviour {
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
