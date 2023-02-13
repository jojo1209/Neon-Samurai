using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TMP_Text scoreText;
    float scoreprovisoire;
    float scoreprovisoireRond;
    float ennemiKillPoint;
    void Start()
    {
        
    }

    void Update()
    {
        scoreprovisoire += Time.deltaTime;
        scoreprovisoireRond = Mathf.Round(scoreprovisoire);
        scoreText.text = "" + scoreprovisoireRond;
    }

    void EnemiKill()
    {
        scoreprovisoire += ennemiKillPoint;
    }
}
