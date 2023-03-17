using UnityEngine;

public class GameManager: MonoBehaviour
{
	[SerializeField] private SettingsData settingsData;
	[SerializeField] private GameObject player;
	[SerializeField] private FloatingJoystick joystickPrefab;
	[SerializeField] private Canvas ui;
	private void Start() {
		Time.timeScale = 1;

		if (settingsData.useJoystick)
		{
			PlayerController playerController = player.AddComponent<PlayerController>();
			FloatingJoystick joystickInstance = Instantiate(joystickPrefab, ui.transform);
			joystickInstance.transform.SetAsFirstSibling();
			playerController.joystick = joystickInstance;
		}
		else
			player.AddComponent<PlayerMouvements>();
	}
}