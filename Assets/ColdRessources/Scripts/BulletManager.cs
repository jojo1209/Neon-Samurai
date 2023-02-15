using UnityEngine;
using System.Collections.Generic;
using System;


public class BulletManager : MonoBehaviour {
	public static BulletManager SharedInstance;
	[SerializeField] private BulletType[] bulletTypes;
	private Dictionary<string, GameObjectPool> bulletPools = new Dictionary<string, GameObjectPool>();

	private void Awake() { if (SharedInstance == null) SharedInstance = this; foreach (BulletType bt in bulletTypes) bulletPools[bt.bulletType] = bt.bulletPool; }
	public GameObject GetBullet(string bulletType) { return bulletPools[bulletType].GetGameObject(); }
	public void ReturnBullet(GameObject bullet, string bulletType) { bulletPools[bulletType].ReturnGameObject(bullet); }
	[Serializable] private class BulletType { public string bulletType; public GameObjectPool bulletPool; }
}