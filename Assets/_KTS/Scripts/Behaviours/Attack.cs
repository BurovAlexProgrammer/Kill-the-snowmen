using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField]
    Target target;
    Damagable damagable;
    GameObject targetGameObject;
    [SerializeField]
    float attackPower = 10;
    [SerializeField]
    float attackRange = 1.5f;
    [SerializeField]
    float attackDelay = 2;
    bool readyToAttack = false;


    public IEnumerator AttackTarget() {
        readyToAttack = false;
        AnimateAttack();
        yield return new WaitForSeconds(attackDelay);
        damagable?.AddDamage(attackPower);
    }

    public void AnimateAttack() { 

    }

    void Start()
    {
        
    }

    void Update()
    {
        if (GetDistance() <= attackRange & readyToAttack)
            AttackTarget();
    }

    float GetDistance()
    {
        return Vector3.Distance(gameObject.transform.position, target.transform.position);
    }

    public Target GetTarget()
    {
        return target;
    }

    public GameObject GetTargetGameObject()
    {
        return targetGameObject;
    }

    public void SetTarget(Target newTarget)
    {
        target = newTarget;
        targetGameObject = newTarget.gameObject;
        damagable = targetGameObject.GetComponent<Damagable>();
    }

    public void SetTarget(GameObject newGameObject)
    {
        var newTarget = newGameObject.GetComponent<Target>();
        if (newTarget)
            SetTarget(newTarget);
        else
            throw new NullReferenceException();
    }
}
