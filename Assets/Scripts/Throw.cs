using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GlobalExtension;

/// <summary>
/// Control throw behaviour
/// </summary>
public class Throw: MonoBehaviour
{
    [Tooltip("RayCaster plane for set direction of throw")]
    [SerializeField]
    Collider raycastPlane;
    [Tooltip("Thing that you will throw")]
    [SerializeField]
    GameObject throwThing;
    [SerializeField]
    float throwForce;
    [SerializeField]
    float fireRate;
    float fireTimer;

    void Start()
    {
        if (raycastPlane.NotExist())
            throw new Exception("Requered object os NULL");
        if (throwThing.NotExist())
            throw new Exception("Requered object os NULL");
        throwThing.SetActive(false);
    }

    void Update()
    {
        if (fireTimer > 0) fireTimer -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0))  //TODO продумать кросс
        {
            if (fireTimer <= 0)
            {
                fireTimer = fireRate;
                Fire();
            }
        }
    }

    public void Fire()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);  //TODO продумать кросс
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Layers.RAY_CASTER_PLANE_INT))
        {
            var throwStart = Camera.main.transform.position;
            if (Camera.main.transform.childCount != 0)
                throwStart = Camera.main.transform.GetChild(0).position;
            Debug.DrawLine(throwStart, hit.point, Color.green, 1);
            var q = Quaternion.FromToRotation(throwStart, hit.transform.position);
            var newThing = Instantiate(throwThing, throwStart, q);
            newThing.SetActive(true);
            newThing.GetComponent<Rigidbody>().AddForce((hit.point - throwStart) * throwForce);
        }
    }
}
