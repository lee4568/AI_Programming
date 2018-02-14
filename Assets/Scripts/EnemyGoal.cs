using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGoal : MonoBehaviour {

    public int Score = 0;

    void Update()
    {
     if(Score >= 100)
        {
            Time.timeScale = 0;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            Score += 1;
            ScoreManager.Instance.EScore();
        }
    }
}
