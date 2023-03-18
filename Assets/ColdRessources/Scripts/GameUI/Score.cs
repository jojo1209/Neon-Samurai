using UnityEngine;
using TMPro;

public class Score : MonoBehaviour {
	public TMP_Text scoreText;
	int score;

	void Start() {
		if (PlayerPrefs.HasKey("Score"))
			PlayerPrefs.SetFloat("Score", 0);
	}

	private void Update() {
		// Retrieve score
		float score = PlayerPrefs.GetFloat("Score");

		// Update score
		score += Time.deltaTime;
		PlayerPrefs.SetFloat("Score", score);
		this.score = (int) score;

		// Update score display
		scoreText.text = this.score.ToString();
	}
}
