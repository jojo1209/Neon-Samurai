using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class GameObjectPool
{
	[Tooltip("The prefab of the bullet")]
	public GameObject prefab;

	[Tooltip("The initial size of the pool")]
	public int minSize = 1;

	private Queue<GameObject> objects = new Queue<GameObject>();

	private void Awake() {
		Expand(minSize);
	}

	public GameObject GetGameObject() {
		if (objects.Count == 0) Expand(1);
		return objects.Dequeue();
	}

	public void ReturnGameObject(GameObject go) {
		objects.Enqueue(go);
	}

	public void Expand(int number) {
		for (int i = 0; i < number; i++) {
			GameObject go = UnityEngine.Object.Instantiate(prefab);
			go.SetActive(false);
			objects.Enqueue(go);
		}
	}
}