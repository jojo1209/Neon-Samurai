using UnityEngine;
using TMPro;

public class Score : MonoBehaviour {
	public TMP_Text scoreText;

	private void Start() {
		PlayerPrefs.SetFloat("Score", 0);
	}

	private void Update() {
		// Retrieve score
		var score = PlayerPrefs.GetFloat("Score");

		// Update score
		score += Time.deltaTime;
		PlayerPrefs.SetFloat("Score", score);

		// Update score display
		scoreText.text = ((int) score).ToString();
	}
}
