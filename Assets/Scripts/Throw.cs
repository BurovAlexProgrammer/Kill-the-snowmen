using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GlobalExtension;

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
            Log($"result: {hit.point.x}-{hit.point.y}");
            Debug.DrawLine(Camera.main.transform.position, hit.point, Color.green, 1);
            var q = Quaternion.FromToRotation(Camera.main.transform.position, hit.transform.position);
            var newThing = Instantiate(throwThing, Camera.main.transform.position, q);
            var direction = hit.point - Camera.main.transform.position;
            newThing.SetActive(true);
            newThing.GetComponent<Rigidbody>().AddForce((hit.point - Camera.main.transform.position) * throwForce);
            //newThing.GetComponent<Rigidbody>().AddForceAtPosition(direction.normalized * throwForce, hit.transform.position);
        }
    }
}
