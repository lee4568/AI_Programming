using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public GameObject Enemy;
    public float Cooltime;
    public float Delaytime;
    public int enemyCnt;
    


	void Start ()
    { 

		
	}
	

	void Update ()
    {
        Cooltime += Time.deltaTime;
        if (Cooltime > Delaytime)
        {
            Cooltime = 0f;
            enemyCnt++;
            GameObject instaceEnemy = Instantiate(Enemy) as GameObject;
            instaceEnemy.name = "Enemy_" + enemyCnt;
            Enemy.GetComponent<CrowdAgent>().target = GameObject.FindGameObjectWithTag("EnemyGoal").transform;
        }
    }
}
