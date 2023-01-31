using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class GameObjectPool {
	[Tooltip("The prefab of the bullet")]
	public GameObject prefab;
	[Tooltip("The initial size of the pool")]
	public int minSize;
	private Queue<GameObject> objects;

	private void Start() {
		Expand(minSize);
	}

	public GameObject GetGameObject() { return objects.Dequeue(); }
	public List<GameObject> GetGameObject(int number) { return objects.Take(number).ToList(); }
	public void ReturnGameObject(GameObject go) { objects.Enqueue(go); }
	public void ReturnGameObjects(List<GameObject> gos) { for (int i = 0; i < gos.Count; i++) objects.Enqueue(gos[i]); }
	public void Expand(int number) {
		for (int i = 0; i < number; i++) {
			GameObject go = UnityEngine.Object.Instantiate(prefab);
			go.SetActive(false);
			objects.Enqueue(go);
		}
	}
	public void Shrink(int number) { if (number <= objects.Count) objects.Take(number); }
}
