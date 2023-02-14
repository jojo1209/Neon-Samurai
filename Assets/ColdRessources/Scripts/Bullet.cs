using UnityEngine;
using System;

public class Bullet : MonoBehaviour {
	[Tooltip("The bullet type")]
	[SerializeField] private string bulletType = "lazer";
	[Tooltip("The speed of the bullet")]
	[SerializeField] private float baseSpeed = 20;

	private float counter = 0;

	private float speed;
	[NonSerialized] public float speedMultiplier = 1;
	internal Vector3 direction;

	private void OnEnable() {
		counter = 0;
		speed = baseSpeed * speedMultiplier;
	}

	private void Update() {
		counter += Time.deltaTime;
		if (counter > 3) {
			BulletManager.SharedInstance.ReturnBullet(gameObject, bulletType);
			gameObject.SetActive(false);
			return;
		}
		transform.position += transform.forward * speed * Time.deltaTime;
		Debug.DrawRay(this.transform.position,this.transform.forward, Color.blue);
	}

	private void OnTriggerEnter(Collider other) {
		Debug.Log(other.name);
		if (other.TryGetComponent<PlayerDeath>(out PlayerDeath player)) {
			player.Die();
			BulletManager.SharedInstance.ReturnBullet(gameObject, bulletType);
			gameObject.SetActive(false);
		}
	}
}
