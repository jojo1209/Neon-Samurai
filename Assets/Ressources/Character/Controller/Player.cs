using System;
using UnityEngine;

public class Player: MonoBehaviour {
	public static Player SharedInstance;
	private void Start() {
		if (SharedInstance == null)
			SharedInstance = this;
	}
}
