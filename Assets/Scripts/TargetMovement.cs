﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour {

    public Vector3 bound;
    public float speed = 100f;

    private Vector3 initialPosition;
    private Vector3 nextMovementPoint;

    void Start()
    {
        initialPosition = transform.position;
        CalculateNextMovementPoint();
    }

    void CalculateNextMovementPoint()
    {
        float posX = Random.Range(initialPosition.x - bound.x, initialPosition.x + bound.x);
        float posY = Random.Range(initialPosition.y - bound.y, initialPosition.y + bound.y);
        float posZ = Random.Range(initialPosition.z - bound.z, initialPosition.z + bound.z);
        nextMovementPoint = initialPosition + new Vector3(posX, posY, posZ);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(nextMovementPoint - transform.position), 1f * Time.deltaTime);
        if (Vector3.Distance(nextMovementPoint, transform.position) <= 10f)
        {
            CalculateNextMovementPoint();
        }
    }
}
