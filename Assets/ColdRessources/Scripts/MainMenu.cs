using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu: MonoBehaviour
{
	[SerializeField] private Button playButton;
	[SerializeField] private Button shopButton;
	[SerializeField] private Button quitButton;
	void Start()
	{
		playButton.onClick.AddListener(() => { SceneManager.LoadScene("EnemiesTestScene"); });
		shopButton.onClick.AddListener(() => { SceneManager.LoadScene("Shop"); });
		quitButton.onClick.AddListener(() => { Application.Quit(); });
	}
}