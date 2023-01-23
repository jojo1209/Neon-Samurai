using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
	[Header("fini")]
	[Tooltip("the player GameObject")]
	public GameObject player;

	//[Tooltip("The groups of a set of bullets")]


	 private List<GrBullet> bulletGroups;


	public void CreateBulletGroup(GameObject bulletGroup , GameObject enemy) // qu'elle attaque par qu'elle ennemie  
    {
		GrBullet grp = Instantiate(bulletGroup, enemy.transform).GetComponent<GrBullet>();
		grp.parent = enemy;

		//grp.transform.position = enemy.transform.position;

		grp.transform.LookAt(player.transform.position);
	}

	// Update is called once per frame
	void Update()
	{
		for (int i = 0; i < bulletGroups.Count; i++)
		{
			bulletGroups[i].Move();
		}
	}

	
}
