using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTigger : MonoBehaviour {

    public GameObject effect;
    public float EnemyHP = 10;

    void OnTriggerEnter(Collider col)
    {
		if(col.gameObject.tag == "EnemyGoal")
        {
            
            Debug.Log("Goal");
            Destroy(gameObject);
        }
        if(col.gameObject.tag == "Bullet")
        {
            EnemyHP -= 5;
            if (EnemyHP == 0f)
                {
                 ScoreManager.Instance.MyScore();
                 Instantiate(effect, transform.position, transform.rotation);
                    Destroy(gameObject);
                } 
        }
	}
}
