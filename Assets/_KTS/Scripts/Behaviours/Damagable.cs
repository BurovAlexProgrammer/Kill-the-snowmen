using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    [Header("Damageable")]
    [SerializeField]
    public float hp = 100;
    [SerializeField]
    GameObject prefabOnDestroy;

    public float GetHp()
    {
        return hp;
    }

    public void Destroy()
    {
        var parent = gameObject.transform.parent ?? transform.root;
        var newPrefab = GameObject.Instantiate(prefabOnDestroy, parent);
        Destroy(gameObject);
    }

    public void AddDamage(float damage)
    {
        hp -= damage;
        if (damage <= 0) Destroy();
    }
}
