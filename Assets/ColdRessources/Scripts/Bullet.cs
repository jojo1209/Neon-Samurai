using UnityEngine;
using System;

public class Bullet : MonoBehaviour {
	[Tooltip("The speed of the bullet")]
	[SerializeField] private float baseSpeed = 200;

	[NonSerialized] public float speedMultiplier = 1;
	[NonSerialized] public float timeToLive = 3;

	private void Start()
	{
		Invoke(nameof(Die), timeToLive);
	}

	private void Die()
	{
		Destroy(gameObject);
	}

	private void Update()
	{
		if (Time.timeScale == 0) return;
		var speed = baseSpeed * speedMultiplier;
		transform.position += transform.forward * speed * Time.timeScale * Time.deltaTime;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (!other.TryGetComponent(out PlayerDeath player)) return;
		player.Die();
		Destroy(gameObject);
	}
}
