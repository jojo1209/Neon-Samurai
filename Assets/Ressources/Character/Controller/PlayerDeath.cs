using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {
	//IL FAUT METTRE LE GAMEOBJECT "MortPrefab" DANS LE CANVAS POUR QUE CA FONCTIONNE
	public GameObject affichageMort;

	public void Die() {
		affichageMort.SetActive(true);
		Time.timeScale = 0;
	}
}
