using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
   [SerializeField] private Button playButton;
   [SerializeField] private Button quitButton;
    void Start() {
		playButton.onClick.AddListener(() => {
			SceneManager.LoadScene("EnemiesTestScene");
		});
        quitButton.onClick.AddListener(() => {
			Application.Quit();
		});
    }
}
