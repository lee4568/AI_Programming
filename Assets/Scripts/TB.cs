using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TB : MonoBehaviour {

    public float BSpeed;
    public Transform target;

	void Start ()
    {

	}
	
	
	void Update ()
    {
        if (target != null)
        {
            target.LookAt(target);
            transform.Translate(0,0, BSpeed * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
        else if(col.gameObject.name == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
