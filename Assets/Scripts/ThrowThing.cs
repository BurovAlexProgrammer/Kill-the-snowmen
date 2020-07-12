using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Behaviour of throw object
/// </summary>
public class ThrowThing : MonoBehaviour
{
    [SerializeField]
    float lifeTime;
    [Tooltip("Prefab that appearence after destroy throw object (on collision or lifetime ended.)")]
    [SerializeField]
    GameObject onDestroy;

    void Start()
    {
    }

    private void FixedUpdate()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime < 0) Destroy();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy();
    }

    void Destroy()
    {
        var destroyInstance = Instantiate(onDestroy, transform.position, transform.rotation);
        destroyInstance.SetActive(true);
        Destroy(gameObject);
    }
}
