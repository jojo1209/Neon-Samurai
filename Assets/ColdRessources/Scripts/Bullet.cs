using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	[Tooltip("The bullet type")]
	[SerializeField] private string bulletType;
	[Tooltip("The speed of the bullet")]
	[SerializeField] private float baseSpeed;

	private float speed;
	private float speedMultiplier;

	private void OnEnable() {
		speed = baseSpeed * speedMultiplier;
	}

	private void Update() {
		transform.position += transform.forward * speed;
	}

	private void OnTriggerEnter(Collider other) {
		if (other.TryGetComponent<PlayerDeath>(out PlayerDeath player)) {
			player.Die();
			BulletManager.SharedInstance.ReturnBullet(gameObject, bulletType);
			gameObject.SetActive(false);
		}
	}
}
