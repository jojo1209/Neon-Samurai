using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public PlayerMouvements player;

	void Update() {
		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch(0);
			Vector2 touchDeltaPosition = touch.deltaPosition;
			player.MoveBy(new Vector3(touchDeltaPosition.x, touchDeltaPosition.y, 0f) * Time.deltaTime);
		}
	}
}
