using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMaker : MonoBehaviour
{

    public GameObject twPrefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray.origin, ray.direction, out hit))
            {
                //Debug.Log(hit.transform.name);
                switch (hit.transform.tag)
                {
                    case "Wall":
                        Instantiate(twPrefab, hit.transform.position + new Vector3(0, 1, 0), twPrefab.transform.rotation);
                        break;

                    case "Ground":
                        Debug.Log("설치불가");
                        break;

                    case "Enemy":
                        Debug.Log("적의 이름" + hit.transform.name);
                        break;
                    case "Player":
                        Debug.Log("설치가 이미 되어있음");
                        Destroy(hit.transform.gameObject);
                        break;
                }
            }
        }
      
    }
}
