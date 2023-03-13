using System;
using UnityEngine;

[Serializable]
public class EnemySpawn {
	public Enemy enemyPrefab;
	public float spawnAt = 0;
	public float screenTime;
	public AnimationCurve xMovement;
	public AnimationCurve yMovement;
}