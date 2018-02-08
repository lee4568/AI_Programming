using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour {

    public bool bDebug = true;
    public float Radius = 2f; //돌아가는 반경
    public Vector3[] pointA;

    public float Length
    {
        get
        {
            return pointA.Length;
        }
    }

    public Vector3 GetPoint(int index)
    {
        return pointA[index];
    }

	void OnDrawGizmos()
    {
		if(!bDebug) // 활성화를 하면 패스의 선이 보이며 비활성화를 하면 패스가 안보인다.
        {
            return;
        }

        for (int i = 0; i < pointA.Length; i++)
        {
            if(i+1<pointA.Length)
            {
                Debug.DrawLine(pointA[i], pointA[i + 1], Color.red);
            }
        }
             
	}
}
