using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class WaveManager: MonoBehaviour
{
	public Transform enemiesContainer;
	[SerializeField] private Wave[] waves;
	[SerializeField] private CanvasRenderer victoryScreen;
	private int waveIndex;
	private List<EnemySpawn> currentWave;
	private int enemyIndex;
	private bool isPlaying = true;
	private float timeNeeded;  // the time the last enemy need to spawn
	private bool waitForNextWave;
	private const float RefreshRate = 1.5f;

	private void Start()
	{
		waveIndex = 0;
		currentWave = new List<EnemySpawn>();
	}

	private void NextWave() {
		if (waveIndex == waves.Length) {
			Invoke(nameof(Victory), 3);;
			isPlaying = false;
			return;
		}

		currentWave = waves[waveIndex].enemies.ToList();
		enemyIndex = 0;
		timeNeeded = 0;
		currentWave.Sort((x,y) => x.spawnAt.CompareTo(y.spawnAt));

		foreach (EnemySpawn enemy in currentWave) {
			if (enemy.spawnAt > timeNeeded) timeNeeded = enemy.spawnAt;
			Invoke(nameof(SpawnEnemy), enemy.spawnAt);
		}

		waitForNextWave = false;
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
		timeNeeded = Mathf.Max(timeNeeded - Time.deltaTime * Time.timeScale, 0);
		var dontCare = waitForNextWave || Time.timeScale == 0 || !isPlaying || enemiesContainer.childCount != 0 || timeNeeded != 0;
		if (dontCare) return;
		waitForNextWave = true;
		NextWave();
	}

	private void Victory()
	{
		CancelInvoke(nameof(SpawnEnemy));
		Time.timeScale = 0;
		var text = $"Victoire\nTon Score :\n{(int)PlayerPrefs.GetFloat("Score")}";
		TMP_Text label = victoryScreen.transform.Find("VictoryLabel").GetComponent<TMP_Text>();
		label.text = text;
		victoryScreen.gameObject.SetActive(true);
	}
}
