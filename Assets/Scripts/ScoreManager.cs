using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public Text Scoretext;
    public Text Enemytext;
    int Score = 0;
    int EnemyScore = 0;

    static ScoreManager _instance = null;
    public static ScoreManager Instance
    {
        get
        {
           if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(ScoreManager)) as ScoreManager;
                if(_instance == null)
                {
                    Debug.Log("Er");
                }
            }
            return _instance;
        }
    }

    public void MyScore()
    {
        Score += 10;
        Scoretext.text = ("Score : "+Score).ToString();
    }
    public void EScore()
    {
        EnemyScore += 1;
        Enemytext.text = ("도망간 적 : " + EnemyScore).ToString();

    }
}
