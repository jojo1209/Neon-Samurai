using UnityEngine;
using System.Collections.Generic;

public class BulletManager : MonoBehaviour {
	public static BulletManager SharedInstance;
	public GameObjectPool[] bulletPool;

	private void Awake() { if (SharedInstance == null) SharedInstance = this; }

	public List<GameObject> GetBullets(int bulletType, int number) { return bulletPool[bulletType].GetGameObject(number); }

	public void ReturnBullet(GameObject bullet, int bulletType) { bulletPool[bulletType].ReturnGameObject(bullet); }

	public void ReturnBullets(List<GameObject> bullets, int bulletType) { bulletPool[bulletType].ReturnGameObjects(bullets); }

	
}
