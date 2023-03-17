using UnityEngine;

public class GameManager: MonoBehaviour
{
	[SerializeField] private SettingsData settingsData;
	[SerializeField] private GameObject player;
	private void Start() {
		Time.timeScale = 1;

		if (settingsData.useJoystick)
		{
			
		}
		else
			player.AddComponent<PlayerMouvements>();
	}
}