using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathPanel : MonoBehaviour {
	[SerializeField] private Button replayButton;
	[SerializeField] private Button respawnButton;
	[SerializeField] private Button quitButton;

	public void Start() {
		replayButton.onClick.AddListener(() => {
			SceneManager.LoadScene("EnemiesTestScene");
		});

		quitButton.onClick.AddListener(()=> {
			SceneManager.LoadScene("MainMenu");
		});
	}
}
