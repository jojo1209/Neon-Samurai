using UnityEngine;

public class GameManager : MonoBehaviour {
	//public PlayerMouvements player;

	private void Start() {
		Time.timeScale = 1;
	}

	void Update() {
		// if (Input.touchCount > 0) {
		// 	Touch touch = Input.GetTouch(0);
		// 	if (touch.phase == TouchPhase.Moved) {
		// 		Vector3 touchGap = touch.deltaPosition.normalized * Time.deltaTime;
		// 		player.MoveBy(touchGap);
		// 	}
		// }
	}
}
