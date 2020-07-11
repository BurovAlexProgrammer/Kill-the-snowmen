using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowThing : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float lifeTime;
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
