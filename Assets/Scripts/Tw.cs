using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tw : MonoBehaviour {

    public float fireCool;
    public float fireDelay;
    public GameObject bullet;
    public Transform firePosition;
    public List<GameObject> LockObj;
    public float RotationSpeed;


    void Start ()
    {
		
	}
	
	
	void Update ()
    { 
        if (LockObj.Count > 0)
        {
            if (LockObj[0] != null)
            {
                Vector3 dir = LockObj[0].transform.position - transform.position;
                dir.y = 0f;
                dir.Normalize();
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), RotationSpeed * Time.deltaTime);
                fireCool += Time.deltaTime;

                if (fireCool > fireDelay)
                {
                    fireCool = 0f;
                    GameObject towerBullet = Instantiate(bullet) as GameObject;
                    firePosition.transform.LookAt(LockObj[0].transform);
                    towerBullet.transform.position = firePosition.position;
                    towerBullet.transform.localRotation = firePosition.rotation;
                }
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log("적!!");
            LockObj.Add(col.gameObject);
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log("적!!");
            LockObj.Remove(col.gameObject);
        }
    }
}
