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
        if (LockObj.Count > 0) //만약 List로 선언한 LockObj의 수가 0이상이면...
        {
            if (LockObj[0] != null) //LockObj의 첫번째가 빈것이 아니라면
            {
                Vector3 dir = LockObj[0].transform.position - transform.position; // 백터3의 방향은 들어온 오브젝트와 나의 방향을 뺀값이다.
                dir.y = 0f; // Y방향은 0이며
                dir.Normalize(); // 백터3로 선언한 방향(dir)을 평준화 한다.
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), RotationSpeed * Time.deltaTime);
                fireCool += Time.deltaTime;
               
                

                if (fireCool > fireDelay)
                {
                    fireCool = 0f;
                    GameObject towerBullet = Instantiate(bullet) as GameObject;
                    
                    firePosition.transform.LookAt(LockObj[0].transform);
                    towerBullet.transform.position = firePosition.position;
                    towerBullet.transform.localRotation = firePosition.rotation;

                    towerBullet.GetComponent<TB>().target = LockObj[0].transform;
                }
              
            }
            else
            {
                LockObj.RemoveAt(0);
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log("들어옴");
            LockObj.Add(col.gameObject);
        }
      
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log("나감");
            LockObj.Remove(col.gameObject);
        }
    }
}
