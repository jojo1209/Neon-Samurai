using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyWave : ScriptableObject {
	public List<EnemySpawn> enemies;
}

[Serializable]
public class EnemySpawn {
	[Tooltip("The prefab of the Enemy")]
    public Enemy enemy;
	[Tooltip("The starting position of the enemy")]
	public Vector3 startPosition;
	[Tooltip("The behaviour of the enemy")]
	public List<EnemyShoot> shoot;
	public List<EnemyMove> move;
}

[Serializable]
public class EnemyMove {
	[Tooltip("The time when the enemy will move")]
	public double when;
	[Tooltip("The position to go to")]
	public Vector3 direction;
	[Tooltip("The time needed for the enemy to get there")]
	public float velocity;
}

[Serializable]
public class EnemyShoot  {
	[Tooltip("The time when the enemy will shoot")]
	public double when;
	[Tooltip("The id of the bullet that will be fired")]
	[SerializeField]
	public int bulletId;
	[Tooltip("The speed of the bullets")]
	public float bulletSpeed;
	[Tooltip("The total time of the bullet animation")]
	public float lifeTime;
	[Tooltip("The animation curve of the bullet")]
	public AnimationCurve animation;
	[Tooltip("The Cooldown of the enemy after shooting the salvo (in seconds)")]
	public float cooldown;
	[Tooltip("The number of bullets that will be shot from the cannon")]
	public int numberOfBullets;
	[Tooltip("The delay between each bullet of the salvo (in seconds")]
	public float delay;
}
