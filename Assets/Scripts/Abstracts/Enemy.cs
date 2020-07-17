using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class Enemy : MonoBehaviour
{
    [Header("Moveable")]
    [Tooltip("Speed meters per second")]
    [SerializeField]
    float speed = 1;
    [SerializeField]
    float rotateSpeed;
    [SerializeField]
    Vector3 moveTarget;
    public void Move()
    {
    }
    public virtual void AnimateMove() {}

    public void Rotate()
    {
    }
    public virtual void AnimateRotate() {}


    [Header("Attackable")]
    Transform AttackTarget;
    [SerializeField]
    float damage = 10;
    [SerializeField]
    float attackRange = 0.5f;
    [Tooltip("Attack rate per secons")]
    [SerializeField]
    float attackRate = 1;
    public void Attack()
    {
    }
    public virtual void AnimateAttack() {}


    [Header("Damageable")]
    [SerializeField]
    public float HP = 100;
    [SerializeField]
    public GameObject PrefabOnDestroy;
    public virtual void Destroy()
    {

    }

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
