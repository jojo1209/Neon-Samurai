using System.Collections.Generic;
using UnityEngine;

public class Enemy: MonoBehaviour
{
	[Header("Shoot mechanic")]
	[SerializeField] private Transform cannonsTransform;
	[SerializeField] private Bullet bulletPrefab;
	[SerializeField] private float startShootingAt;
	[SerializeField] private float cooldown;
	[SerializeField] private int nbConsecutiveShot;
	[SerializeField] private float cdBetweenShots;
	[SerializeField] private int numberOfShot;
	[SerializeField] private float bulletTimeToLive;
	[SerializeField] private float bulletSpeedMultiplier;

	[Space]
	[Header("Score")]
	[SerializeField] [Tooltip("The score increment when the player kills it")]
	private int value = 10;
	private List<Transform> cannons;
	// movement mechanic
	public AnimationCurve xMovement;
	public AnimationCurve yMovement;
	public float screenTime;
	public float timeSinceCreation;

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
			Bullet bullet = Instantiate(bulletPrefab);
			bullet.transform.position = cannon.position;
			bullet.transform.rotation = cannon.rotation;
			bullet.speedMultiplier = bulletSpeedMultiplier;
			bullet.timeToLive = bulletTimeToLive;
		}
	}

	private void Update()
	{
		timeSinceCreation += Time.deltaTime;
		
		// not on screen anymore
		if (timeSinceCreation >= screenTime) { Destroy(gameObject); return; }
		
		// update position
		var x = xMovement.Evaluate(timeSinceCreation / screenTime);
		var y = yMovement.Evaluate(timeSinceCreation / screenTime);
		transform.position = Camera.main.ViewportToScreenPoint(new Vector2(x, y));
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