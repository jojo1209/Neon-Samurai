using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;
	
	public void Awake()
	{
		if (Instance == null)
			Instance = this;
	}

	private void Start() {
		Time.timeScale = 1;
	}
}
