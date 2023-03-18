using UnityEngine;
using UnityEngine.UI;

public class BulletTimeButton: MonoBehaviour {
	[SerializeField] private Sprite activableSprite;
	[SerializeField] private Sprite nonActivableSprite;
	[Min(0)]
	[SerializeField] private float cooldown;
	[Min(0.5f)]
	[SerializeField] private float duration;
	[Range(0.1f, 0.9f)]
	[SerializeField] private float bulletTimeSpeed;
	private Image image;
	private Slider slider;
	private bool wasActivated;
	private float timeElapsedSinceActivation;

	private void Start() {
		image = GetComponent<Image>();
		slider = transform.Find("Slider").GetComponent<Slider>();
		image.sprite = activableSprite;
	}

	private void Update() {
		if (!wasActivated) return;
		timeElapsedSinceActivation += Time.deltaTime;
		slider.value = timeElapsedSinceActivation / cooldown;
		if (timeElapsedSinceActivation >= cooldown)
			ActivateButton();
	}

	public void ButtonPressed() {
		if (!wasActivated)
			DeactivateButton();
	}

	public void StopBulletTime() {
		if (Time.timeScale != 0)
			Time.timeScale = 1;
	}

	private void ActivateButton() {
		wasActivated = false;
		timeElapsedSinceActivation = 0;
		slider.gameObject.SetActive(false);
		slider.value = 0;
		image.sprite = activableSprite;
	}

	private void DeactivateButton() {
		wasActivated = true;
		slider.gameObject.SetActive(true);
		image.sprite = nonActivableSprite;
		Time.timeScale = bulletTimeSpeed;
		Invoke(nameof(StopBulletTime), duration);
	}
}
