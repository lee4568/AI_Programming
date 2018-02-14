using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class CrowdAgent : MonoBehaviour {

    public Transform target;
    private NavMeshAgent agent;
    public float angetSpeedmin;
    public float angetSpeedmax;

	
	void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = Random.Range(angetSpeedmin,angetSpeedmax);
        agent.SetDestination(target.position);
	}
}
