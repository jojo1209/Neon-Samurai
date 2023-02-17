// using UnityEngine;
// using System.Collections.Generic;

// public class WaveManager: MonoBehaviour {
// 	public List<EnemyWave> waves;
// 	private double timer = 0;
// 	private EnemyWave currentWave;

// 	private void Start() {
// 		if (waves.Count > 0) {
// 			CreateWave();
// 		}
// 	}

// 	private void CreateWave() {
// 		currentWave = waves[0];
// 		waves.RemoveAt(0);
// 		var spawn = currentWave.enemies;
// 		for (int i = 0; i < spawn.Count; i++) {
// 			var startPosition = spawn[i].startPosition;
// 			var enemy = spawn[i].enemy;
// 			enemy.transform.position = startPosition;
// 		}
// 	}

// 	private void Update() {
// 		timer += Time.deltaTime;
// 		foreach (EnemySpawn enemy in currentWave.enemies) {
// 			while (timer > enemy.shoot[0].when) {
// 				enemy.enemy.StartShooting(enemy.shoot[0]);
// 				enemy.shoot.RemoveAt(0);
// 			}
// 			while (timer > enemy.move[0].when) {
// 				enemy.move.RemoveAt(0);
// 			}
// 		}
// 	}

// }
