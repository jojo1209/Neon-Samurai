using System.Collections.Generic;
using UnityEngine;

public class Enemy: MonoBehaviour
{
	[Header("Shoot mechanic")]
	[SerializeField] private Transform cannonsTransform;
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
	[SerializeField] [Tooltip("The score increment when the player kills it")]
	private int value = 10;

	private List<Transform> cannons;

	private void Start()
	{
		cannons = new List<Transform>();
		for (var i = 0; i < cannonsTransform.childCount; i++) cannons.Add(cannonsTransform.GetChild(i));
		InvokeRepeating(nameof(StartShooting), startShootingAt, cooldown + nbConsecutiveShot * cdBetweenShots);
		Invoke(nameof(StopShooting), startShootingAt + numberOfShot * cooldown);
	}

	private void StartShooting()
	{
		for (int i = 0; i < nbConsecutiveShot; i++)
			Invoke(nameof(Shoot), i * cdBetweenShots);
	}

	private void StopShooting()
	{
		CancelInvoke(nameof(StartShooting));
	}

	private void Shoot()
	{
		foreach (Transform cannon in cannons)
		{
			Bullet bullet = Instantiate(bulletPrefab, cannon);
			bullet.speedMultiplier = bulletSpeedMultiplier;
			bullet.timeToLive = bulletTimeToLive;
		}
	}

	public void Die()
	{
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