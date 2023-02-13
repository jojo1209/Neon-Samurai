using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public int bulletType;
	[Tooltip("The speed of the bullets")]
	public AnimationCurve curve;
	[Tooltip("The speed of the bullet")]
	public float speed;
	[Tooltip("The total time of the bullet animation")]
	public float lifeTime;
	public bool trackingTarget;
	public GameObject target;

	private float timeElapsed;
	private Vector3 startPosition;

	private void OnEnable() {
		timeElapsed = 0;
		startPosition = transform.position;
	}

	private void Update() {
		timeElapsed += Time.deltaTime;
		float curveValue = curve.Evaluate(timeElapsed / lifeTime);
		if (trackingTarget)
			transform.LookAt(target.transform);

		// Move the bullet along the curve
		transform.position = startPosition + transform.forward * speed * curveValue;
	}

	/// <summary>
	/// The function that is called when the Bullet collides with something
	/// </summary>
	/// <param name="other">The collider of the object that collides with the bullet</param>
	private void OnTriggerEnter(Collider other) {
		if (other.TryGetComponent<PlayerDeath>(out PlayerDeath player)) {
			player.Die();
			BulletManager.SharedInstance.ReturnBullet(gameObject, bulletType);
			gameObject.SetActive(false);
		}
	}
}
