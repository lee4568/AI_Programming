using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Node : IComparable {

    public float nodeTotalCost;
    public float estimatedCost;
    public bool bObstacle;
    public Node parent;
    public Vector3 position;
    

    public Node ()
    {
        estimatedCost = 0f;
        nodeTotalCost = 1f;
        bObstacle = false;
        parent = null;
    }
    public Node(Vector3 pos)
    {
        estimatedCost = 0f;
        nodeTotalCost = 1f;
        bObstacle = false;
        parent = null;
        position = pos;
    }
    public void MarkAsObstacle ()
    {
        bObstacle = true;
	}
    public int CompareTo(object obj)
    {
        Node node = (Node)obj;
        if(estimatedCost < node.estimatedCost)
        {
            return -1;
        }
        if(estimatedCost>node.estimatedCost)
        {
            return 1;
        }
        return 0;
    }

}
