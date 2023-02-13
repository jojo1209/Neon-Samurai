using UnityEngine;
using System.Collections.Generic;

public class BulletManager : MonoBehaviour {
	public static BulletManager SharedInstance;
	public Dictionary<string, GameObjectPool> bulletPool;

	private void Awake() { if (SharedInstance == null) SharedInstance = this; }

	public List<GameObject> GetBullets(string bulletType, int number) { return bulletPool[bulletType].GetGameObject(number); }

	public void ReturnBullet(GameObject bullet, string bulletType) { bulletPool[bulletType].ReturnGameObject(bullet); }

	public void ReturnBullets(List<GameObject> bullets, string bulletType) { bulletPool[bulletType].ReturnGameObjects(bullets); }
}
