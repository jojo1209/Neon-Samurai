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
	private int timeNeeded;  // the time the last enemy need to spawn

	private void Start()
	{
		waveIndex = 0;
		currentWave = new List<EnemySpawn>();
		WaveUpdate();
	}
	
	public void NextWave() {
		Debug.Log(nameof(NextWave));
		if (waveIndex >= waves.Length) {
			Invoke(nameof(Victory), 3);;
			isPlaying = false;
			return;
		}

		currentWave = waves[waveIndex].enemies.ToList();
		var waveEnd = 0f;
		enemyIndex = 0;
		timeNeeded = 0;
		currentWave.Sort((x,y) => x.spawnAt.CompareTo(y.spawnAt));

		foreach (EnemySpawn enemy in currentWave) {
			var deathTime = enemy.screenTime + enemy.spawnAt;
			if (deathTime > waveEnd) waveEnd = deathTime;
			if (enemy.spawnAt > timeNeeded) timeNeeded = Mathf.CeilToInt(enemy.spawnAt);
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

	private void WaveUpdate()
	{
		Invoke(nameof(WaveUpdate), 1);
		timeNeeded -= 1;
		if (Time.timeScale == 0) return;
		if (!isPlaying) return;
		if (enemiesContainer.childCount != 0) return;
		if (timeNeeded != 0) return;
		NextWave();
	}

	private void Victory()
	{
		CancelInvoke(nameof(SpawnEnemy));
		Time.timeScale = 0;
		var text = "Victoire\nTon Score :\n" + PlayerPrefs.GetInt("Score");
		var label = victoryScreen.transform.Find("VictoryLabel").GetComponent<TMP_Text>();
		label.text = text;
		victoryScreen.gameObject.SetActive(true);
	}
}
