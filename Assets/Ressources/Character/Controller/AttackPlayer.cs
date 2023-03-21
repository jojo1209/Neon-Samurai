using System;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
	public float cooldown = 0.75f;
	[SerializeField] private PlayerAnimation playerAnimation;
	private AudioSource attackSound;
	private List<Enemy> enemyList;
	private bool canAttack;

	private void Start()
	{
        canAttack = true;
		enemyList = new List<Enemy>();
		attackSound = GetComponent<AudioSource>();
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
		canAttack = false;
		// play animation
		playerAnimation.OnAttack();
		// play sound
		attackSound.Play();
		Invoke(nameof(AttackReady), cooldown/Time.timeScale);
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
