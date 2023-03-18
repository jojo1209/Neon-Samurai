using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings: MonoBehaviour {
	[SerializeField] private SettingsData settingsData;
	[SerializeField] private Button backButton;
	[SerializeField] private Slider useJoystickSlider;

	private void Start() {
		backButton.onClick.AddListener(() => gameObject.SetActive(false));
		UseJoystick(settingsData.useJoystick);
	}

	private void UseJoystick(bool choice) {
		int intChoice = choice ? 1 : 0;
		PlayerPrefs.SetInt("Joystick", intChoice);
		useJoystickSlider.value = intChoice;
		settingsData.useJoystick = choice;
	}

	public void ToggleJoystickUse() {
		UseJoystick(!settingsData.useJoystick);
	}
}