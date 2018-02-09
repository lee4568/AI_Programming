using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCode : MonoBehaviour {

    private Transform startPos, endPos;
    public Node startNode { get;  set; }
    public Node goalNode { get; set; }

    public ArrayList pathArray;

    GameObject objsStartCube, objEndCube;
    private float elapsedTime = 0f;
    public float intervaltime = 1f;

	void Start ()
    {
        objsStartCube = GameObject.FindGameObjectWithTag("Start");
        objEndCube = GameObject.FindGameObjectWithTag("End");

        pathArray = new ArrayList();
        FindPath();
    }

    void Update()
    {
    
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= intervaltime)
        {
            elapsedTime = 0f;
            FindPath();
        }
    }

    void FindPath ()
    {
        startPos = objsStartCube.transform;
        endPos = objEndCube.transform;

        startNode = new Node(GridManager.instance.GetGridCellCenter(GridManager.instance.GetGridIndex(startPos.position)));
        goalNode = new Node(GridManager.instance.GetGridCellCenter(GridManager.instance.GetGridIndex(endPos.position)));

        pathArray = ASter.FindPath(startNode, goalNode);

    }

    void OnDrawGizmos()
    {
        if(pathArray == null) return;
        
        if (pathArray.Count > 0)
        {
            int index = 1;
            foreach (Node node in pathArray)
            {
                if (index < pathArray.Count)
                {
                    Node nextNode = (Node)pathArray[index];
                    Debug.DrawLine(node.position, nextNode.position, Color.green);
                    index++;
                }
            }
        }
    }
}
