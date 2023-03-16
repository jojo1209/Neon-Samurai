using System;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
	public List<Enemy> enemyList;
	public float cooldown = 1;
	[NonSerialized] public bool canAttack;
	[SerializeField] private AudioSource attaque;
	[SerializeField] private PlayerAnimation playerAnimation;

	private void Start()
	{
        canAttack = true;
	}

	private void Update()
	{
		Attack();
	}

	private void Attack()  {
		if(!canAttack) return;
		if(enemyList.Count <= 0) return;
		enemyList[0].Die();
		enemyList.RemoveAt(0);
		// play sound
		attaque.Play();
		// play animation
		playerAnimation.OnAttack();
		canAttack = false;
		Invoke(nameof(AttackReady), cooldown);
	}


	private void AttackReady() {
		canAttack = true;
	}

	private void OnTriggerEnter(Collider other) {
		if (other.TryGetComponent(out Enemy e))
			enemyList.Add(e);
	}

	private void OnTriggerExit(Collider other) {
		if (other.TryGetComponent(out Enemy e))
			enemyList.Remove(e);
	}
}
