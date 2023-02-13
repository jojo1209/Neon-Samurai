using UnityEngine;
using System;

public class Bullet : MonoBehaviour {
	[Tooltip("The bullet type")]
	[SerializeField] private string bulletType = "lazer";
	[Tooltip("The speed of the bullet")]
	[SerializeField] private float baseSpeed = 10;

	private float speed;
	[NonSerialized] public float speedMultiplier = 1;

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
