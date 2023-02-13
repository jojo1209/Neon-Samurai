using UnityEngine;

public class PlayerDeath : MonoBehaviour {
	public static PlayerDeath SharedInstance;
	private void Awake() {
		if (SharedInstance == null)
			SharedInstance = this;
	}
	public void Die() {
		
	}
}
