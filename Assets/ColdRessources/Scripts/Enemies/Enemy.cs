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

	private void Start() {
		if (!targetPlayer) {
			foreach (GameObject cannon in cannons) {
				cannon.transform.Rotate(90, 0, 0);
			}
		}
	}

	public void Shoot() {
		for (int i = 0; i < cannons.Count; i++) {
			// get bullets
			string bulletType = paterns[paternIndex].bulletTypes[i];
			Bullet bullet = BulletManager.SharedInstance.GetBullet(bulletType).GetComponent<Bullet>();

			// prepare shoot
			var cannon = cannons[i];
			// set the position
			bullet.transform.position = cannon.transform.position;
			// set the rotation
			if (!targetPlayer) {
				var cannonRot = cannon.transform.rotation;
				bullet.transform.rotation = Quaternion.Euler(cannonRot.x + 90, cannonRot.y, 0);
			}
			else
				bullet.transform.LookAt(Player.SharedInstance.transform);
			// bullet.direction = cannon.transform.forward;
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
				cannon.transform.LookAt(Player.SharedInstance.transform, Vector3.down);
				cannon.transform.Rotate(90, 0, 0);
			}

		
	}

	public void Die() {
		// todo increment score though
		// Destroy(gameObject);
		Debug.Log("mort ennemie");
	}
}
