using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TB : MonoBehaviour {

    public float BSpeed;

	void Start ()
    {
        Destroy(gameObject, 2f);
	}
	
	
	void Update ()
    {
        transform.Translate(0,0,BSpeed * Time.deltaTime);
	}
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
