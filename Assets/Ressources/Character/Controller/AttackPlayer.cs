using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
	public List<Enemy> enemyList;
	public float cooldown = 1;
	public bool canAttack;
	public PlayerAnimation anim_Attack;

	void Start()
	{
		canAttack = true;
	}

	private void Update()
	{
		Attack();
	}

	public void Attack()  {
		if(!canAttack) return;
		if(enemyList.Count <= 0) return;
		anim_Attack.OnAttack();
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
}
