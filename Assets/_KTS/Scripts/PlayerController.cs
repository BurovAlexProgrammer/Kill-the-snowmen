using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Rotation
    [Tooltip("Max camera rotation")]
    [SerializeField]
    [Range(0, 360)]
    int maxAngle;
    float startRotation;
    float rotateDiff = 0;

    //Boost rotation
    [Tooltip("Rotate boost on long press")]
    [SerializeField]
    float rotateBoost = 2;
    [Tooltip("Enable boost after time in seconds")]
    [SerializeField]
    float rotateBoostTime = 1;
    float rotateBooster = 1;
    private float boostTimer;


    void Start()
    {
        startRotation = transform.eulerAngles.y;
    }

    private void FixedUpdate()
    {
        var rotation = Input.GetAxis("Horizontal") * rotateBooster;
        rotateDiff += rotation;
        if (rotation != 0)
        {
            if (Input.GetAxisRaw("Horizontal") != 0)
                boostTimer -= Time.deltaTime;
            else
                boostTimer = rotateBoostTime;
            rotateBooster = boostTimer < 0 ? rotateBoost : 1;
            if (rotateDiff > maxAngle / 2)
                rotateDiff = maxAngle / 2;
            if (rotateDiff < maxAngle / 2 * -1)
                rotateDiff = maxAngle / 2 * -1;
        }
        transform.SetEulerY(startRotation + rotateDiff);
    }
}
