using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Enemy : MonoBehaviour
{
    [Header("Moveable")]
    [Tooltip("Speed meters per second")]
    [SerializeField]
    float speed = 1f;
    [SerializeField]
    float rotateSpeed;
    [SerializeField]
    Vector3 moveTarget;

    public void Move()
    {
    }
    public void AnimateMove() { }


    private void Start()
    {

    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {

    }
}
