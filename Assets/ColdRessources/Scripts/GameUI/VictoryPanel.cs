using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VictoryPanel: MonoBehaviour
{
	private void Start()
	{
		Button mainMenuButton = transform.Find("MainMenuButton").GetComponent<Button>();
		mainMenuButton.onClick.AddListener(() => { SceneManager.LoadScene("Game"); });
	}
}