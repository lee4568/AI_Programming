using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class TankAi : MonoBehaviour {

    private GameObject player;
    private Animator animator;
    private Ray ray;
    private RaycastHit hit;
    private float maxDistanceToCheck = 6f; // 체크할수있는 최대 거리
    private float currentDistance; // 현재 거리
    private Vector3 checkDirection; 

    public Transform pointA;
    public Transform pointB;
    public NavMeshAgent navMeshAgent;

    private int currentTarget;
    private float distanceFormTarget; // 타겟과의 거리
    private Transform[] waypoints = null;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        animator = gameObject.GetComponent<Animator>();
        pointA = GameObject.Find("p1").transform;
        pointB = GameObject.Find("p2").transform;
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        waypoints = new Transform[2]
        {
            pointA,pointB 
        }; // waypoints[0] = pointA; waypoints[1] = pointB; 랑 같은 방식

        currentTarget = 0;
        navMeshAgent.SetDestination(waypoints[currentTarget].position); // 새로운 경로에 대한 계산 트리거 같은 목적지를 설정하거나 업데이트
    }
	void FixedUpdate ()
    {
        currentDistance = Vector3.Distance(player.transform.position,transform.position);
        animator.SetFloat("distanceFormPlayer", currentDistance);
        checkDirection = player.transform.position - transform.position;
        ray = new Ray(transform.position, checkDirection);
        if(Physics.Raycast(ray,out hit,maxDistanceToCheck))
        {
            if(hit.collider.gameObject == player) // 충돌한 콜라이더의 게임오브젝트가 플레이어 라면
            {
                animator.SetBool("isPlayerVisible", true); // 애니메이터의 상태를 true로 변경하며
            }
            else
            {
                animator.SetBool("isPlayerVisible", false);// 아니라면 false로 변경한다.
            }
        }
        else
        {
            animator.SetBool("isPlayerVisible", false);
        }
        distanceFormTarget = Vector3.Distance(waypoints[currentTarget].position, transform.position);
        animator.SetFloat("distanceFormWaypoint", distanceFormTarget);
    }
    public void SetNextPoint()
    {
        switch (currentTarget)
        {
            case 0:
                currentTarget = 1;
                break;
            case 1:
                currentTarget = 0;
                break;
        }
        navMeshAgent.SetDestination(waypoints[currentTarget].position);
    }
}
