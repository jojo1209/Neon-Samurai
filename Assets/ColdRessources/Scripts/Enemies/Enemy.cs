using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[Header("Enemy Behaviour")]
	public Health health;
	[Tooltip("The GameObjects that will shoot bullets")]
	public GameObject[] cannons;
	private List<List<GameObject>> bullets;
	private float cooldown;

	/// <summary>
	/// The function that setup the enemy attacks
	/// </summary>
	public void StartShooting(EnemyShoot es, bool attach=false) {
		// prepare shooting
		// InvokeRepeating("Shoot", cooldown, es.delay);
	}

	/// <summary>
	/// The Enemy Attack
	/// </summary>
	public void Shoot() {
		// shoot bullets
	}
}
