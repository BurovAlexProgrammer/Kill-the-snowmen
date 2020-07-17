using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Tooltip("Max camera rotation")]
    [SerializeField]
    [Range(0, 360)]
    int maxAngle;
    public float temp;
    public float currAngle;

    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        temp = Input.GetAxis("Horizontal");
        currAngle += Input.GetAxis("Horizontal");

    }
}
