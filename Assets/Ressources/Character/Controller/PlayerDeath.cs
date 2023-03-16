using UnityEngine;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour {
	public CanvasRenderer deathDisplay;
	public PlayerAnimation Anim_death;
	public void Die() {
		Anim_death.OnDead();
		deathDisplay.gameObject.SetActive(true);
		Time.timeScale = 0;
	}
}
