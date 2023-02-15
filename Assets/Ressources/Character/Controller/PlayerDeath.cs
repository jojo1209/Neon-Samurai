using UnityEngine;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour {
	public CanvasRenderer deathDisplay;

	public void Die() {
		deathDisplay.gameObject.SetActive(true);
		Time.timeScale = 0;
	}
}
