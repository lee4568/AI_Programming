using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriorityQueue
{

    private ArrayList nodes = new ArrayList();
    public int Length
    {
        get
        {
            return nodes.Count;
        }
    }
    public bool Contains(object node)
    {
        return nodes.Contains(node);
    }
    public Node First()
    {
        if(nodes.Count > 0)
        {
            return (Node)nodes[0]; //노드의 첫번째 배열을 반환한다.
        }
        return null;
    }
    public void Push(Node node)
    {
        nodes.Add(node);
        nodes.Sort();
    }
    public void Remove(Node node)
    {
        nodes.Remove(node);
        nodes.Sort();
    }

}
