using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] private float cooldown = 0;
	[SerializeField] private List<List<string>> paterns;
	[SerializeField] private List<GameObject> cannons;
	[SerializeField] private bool targetPlayer = false;
	private float cdCounter = 0;
	private int paternIndex = 0;

	public void Shoot() {
		// get bullets
		for (int i = 0; i <= paterns[paternIndex].Count; i++)
		{
			string bulletType = paterns[paternIndex][i];
			var bullet = BulletManager.SharedInstance.GetBullets(bulletType, 1)[0];

			// prepare shoot
			var cannon = cannons[i];
			// if the bullet target the player, it takes the player
			if (targetPlayer)
				bullet.transform.LookAt(PlayerDeath.SharedInstance.transform);
			else
				bullet.transform.rotation = cannon.transform.rotation;
			
		}

		// update index for next shoot
		paternIndex = (paternIndex + 1) % paterns.Count;
	}

	private void Start() {

	}

	private void Update() {
		cdCounter += Time.deltaTime;
		if (cdCounter >= cooldown) {
			Shoot();
		}
	}

	public void Die() {
		Destroy(gameObject);
	}

	private void OnDestroy() {

	}
}
