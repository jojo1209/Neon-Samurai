using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaveManager: MonoBehaviour
{
	public Transform enemiesContainer;
	[SerializeField] private Wave[] waves;
	private int waveIndex;
	private List<EnemySpawn> currentWave;
	private int enemyIndex;

	private void Start()
	{
		waveIndex = 0;
		currentWave = new List<EnemySpawn>();
		NextWave();
	}
	
	public void NextWave() {
		CancelInvoke(nameof(NextWave));
		if (waveIndex >= waves.Length) {
			// todo victory screen
			Debug.Log("Victory");
			return;
		}

		Debug.Log("Next Wave");

		currentWave = waves[waveIndex].enemies.ToList();
		var waveEnd = 0f;
		enemyIndex = 0;
		currentWave.Sort((x,y) => x.spawnAt.CompareTo(y.spawnAt));

		foreach (EnemySpawn enemy in currentWave) {
			var deathTime = enemy.screenTime + enemy.spawnAt;
			if (deathTime > waveEnd) waveEnd = deathTime;
			Invoke(nameof(SpawnEnemy), enemy.spawnAt);
		}
		waveIndex++;
		Invoke(nameof(NextWave), waveEnd+1);
	}

	public void SpawnEnemy() {
		EnemySpawn enemy = currentWave[enemyIndex];
		enemyIndex++;
		Enemy instance = Instantiate(enemy.enemyPrefab, enemiesContainer);
		instance.xMovement = enemy.xMovement;
		instance.yMovement = enemy.yMovement;
		instance.screenTime = enemy.screenTime;
	}

	private void Update()
	{
		if (enemiesContainer.childCount == 0)
			NextWave();
	}
}
