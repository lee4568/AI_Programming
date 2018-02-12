using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTigger : MonoBehaviour {

    void OnTriggerEnter(Collider col)
    {
		if(col.gameObject.tag == "EnemyGoal")
        {
            Debug.Log("Goal");
            Destroy(gameObject);
        }
        if(col.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
	}
}
