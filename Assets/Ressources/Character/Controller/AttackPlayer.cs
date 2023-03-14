using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
	public List<Enemy> enemyList;
	public float cooldown = 1;
	public bool canAttack;
	
	private bool isBulletTimeActivated;
	

	void Start()
	{
		canAttack = true;
		isBulletTimeActivated = false;
	}

	private void Update()
	{
		Attack();
	}

	public void Attack()  {
		if(!canAttack) return;
		if(enemyList.Count <= 0) return;

		enemyList[0].Die();
		enemyList.RemoveAt(0);
		canAttack = false;
		Invoke("AttackReady", cooldown);
	}


	void AttackReady()
	{
		canAttack = true;
	}

	private void OnTriggerEnter(Collider other) {
		if (other.TryGetComponent<Enemy>(out Enemy e))
			enemyList.Add(e);
	}

	private void OnTriggerExit(Collider other) {
		if (other.TryGetComponent<Enemy>(out Enemy e))
			enemyList.Remove(e);
	}

	public void ActivateBulletTime()
	{
		isBulletTimeActivated = true;
		Time.timeScale = 0.1f;
		Invoke(nameof(DeactivateBulletTime), 3);
	}

	public void DeactivateBulletTime()
	{
		isBulletTimeActivated = false;
		Time.timeScale = 1f;
	}
}
