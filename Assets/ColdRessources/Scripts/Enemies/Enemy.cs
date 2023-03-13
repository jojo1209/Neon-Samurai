using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : MonoBehaviour {
	[Header("Shoot mechanic")]
	[SerializeField] private List<GameObject> cannons;
	[SerializeField] private Bullet bulletPrefab;
	[SerializeField] private float startShootingAt = 0;
	[SerializeField] private float cooldown = 1;
	[SerializeField] private int nbConsecutiveShot = 2;
	[SerializeField] private float cdBetweenShots = 0.3f;
	[SerializeField] private int numberOfShot = 3;
	[SerializeField] private float bulletTimeToLive = 3;
	[SerializeField] private float bulletSpeedMultiplier = 1;
	[Space]
	[Header("Score")]
	[Tooltip("The score increment when the player kills it")]
	[SerializeField] private int value = 10;

	private void Start()
	{
		foreach (GameObject cannon in cannons) {
			cannon.transform.Rotate(90, 0, 0);
		}
		InvokeRepeating(nameof(StartShooting), startShootingAt, cooldown+nbConsecutiveShot*cdBetweenShots);
		Invoke(nameof(StopShooting), startShootingAt + numberOfShot * cooldown);
	}

	private void StartShooting()
	{
		for (int i = 0; i < nbConsecutiveShot; i++)
		{
			Invoke(nameof(Shoot), i*cdBetweenShots);
		}
	}

	private void StopShooting()
	{
		CancelInvoke(nameof(StartShooting));
	}

	private void Shoot()
	{
		foreach (Bullet bullet in cannons.Select(cannon => Instantiate(bulletPrefab, cannon.transform)))
		{
			bullet.speedMultiplier = bulletSpeedMultiplier;
			bullet.timeToLive = bulletTimeToLive;
		}
	}

	public void Die() {
		// Update score
		var score = PlayerPrefs.GetFloat("Score");
		PlayerPrefs.SetFloat("Score", score + value);
		// Death
		Destroy(gameObject);
	}

	private void OnDestroy()
	{
		CancelInvoke(nameof(StopShooting));
		StopShooting();
		CancelInvoke(nameof(Shoot));
	}
}
