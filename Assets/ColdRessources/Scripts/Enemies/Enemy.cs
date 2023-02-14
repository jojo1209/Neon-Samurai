using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] private float cooldown = 0;
	[SerializeField] private List<Patern> paterns;
	[SerializeField] private List<GameObject> cannons;
	[SerializeField] private bool targetPlayer = false;
	[Tooltip("The score increment when the player kills it")]
	[SerializeField] private int value;
	[SerializeField] private float bulletSpeedMultiplier;
	private float cdCounter = 0;
	private int paternIndex = 0;

	public void Shoot() {
		// get bullets
		for (int i = 0; i < cannons.Count; i++)
		{
			string bulletType = paterns[paternIndex].bulletTypes[i];
			Bullet bullet = BulletManager.SharedInstance.GetBullet(bulletType).GetComponent<Bullet>();

			// prepare shoot
			var cannon = cannons[i];
			// set the rotation
			bullet.transform.rotation = cannon.transform.rotation;
			bullet.direction = cannon.transform.forward - new Vector3(0, 90, 0);
			// set the position
			bullet.transform.position = cannon.transform.position;
			bullet.speedMultiplier = bulletSpeedMultiplier;
			bullet.gameObject.SetActive(true);
		}

		// update index for next shoot
		paternIndex = (paternIndex + 1) % paterns.Count;
	}

	private void Update() {
		cdCounter += Time.deltaTime;
		if (cdCounter >= cooldown) {
			Shoot();
			cdCounter %= cooldown;
		}
		if (targetPlayer)
			foreach (GameObject cannon in cannons) {
				cannon.transform.LookAt(Player.SharedInstance.transform);
				var rot = cannon.transform.rotation;
				cannon.transform.rotation = Quaternion.Euler(rot.x, rot.y, 0);
			}
	}

	public void Die() {
		// todo increment score though
		// Destroy(gameObject);
	}
}
