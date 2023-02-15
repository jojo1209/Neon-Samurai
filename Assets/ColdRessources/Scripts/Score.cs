using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
	public TMP_Text scoreText;
	float scoreprovisoire;
	int scoreprovisoireRond;
	float ennemiKillPoint;

	void Update()
	{
		scoreprovisoire += Time.deltaTime;
		scoreprovisoireRond = (int) scoreprovisoire;
		scoreText.text = "" + scoreprovisoireRond;
	}
}
