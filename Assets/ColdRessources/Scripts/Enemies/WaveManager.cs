using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaveManager: MonoBehaviour
{
	public Transform enemiesContainer;
	[SerializeField] private Wave[] waves;
	[SerializeField] private CanvasRenderer VictoryScreen;
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
		if (waveIndex >= waves.Length) {
			Invoke(nameof(Victory), 3);
			return;
		}

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
		if (Time.timeScale == 0) return;
		if (enemiesContainer.childCount == 0)
			NextWave();
	}

	private void Victory()
	{
		Time.timeScale = 0;
		VictoryScreen.gameObject.SetActive(true);
	}
}
