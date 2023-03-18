using UnityEngine;

public class PlayerDeath : MonoBehaviour {
	public CanvasRenderer deathDisplay;
	public void Die()
	{
		PlayerAnimation playerAnimation = GetComponent<PlayerAnimation>();
		playerAnimation.OnDead();
		deathDisplay.gameObject.SetActive(true);
		Time.timeScale = 0;
	}
}
