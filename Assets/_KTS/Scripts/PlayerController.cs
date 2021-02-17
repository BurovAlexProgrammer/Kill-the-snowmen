using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Camera playerCamera;
    //Rotation
    [Tooltip("Max horizontal rotation")]
    [SerializeField]
    [Range(0, 360)]
    int maxHorizontalAngle;
    [Tooltip("Max vertical rotation")]
    [SerializeField]
    [Range(0, 180)]
    int maxVerticalAngle = 80;
    //float startRotation;
    //float rotateDiff = 0;

    void Start()
    {
        //startRotation = transform.eulerAngles.y;
    }

    public void Rotate(Quaternion q)
    {
        var newRotation = transform.localRotation * q;
        var angle = newRotation.eulerAngles.y.ConvertEulerAngle180();
        if (angle <= maxHorizontalAngle / 2 &&
            angle >= -maxHorizontalAngle / 2) 
            transform.localRotation = newRotation;
    }

    public void TiltCamera(Quaternion q)
    {
        var newRotation = playerCamera.transform.localRotation * q;
        var angle = newRotation.eulerAngles.x.ConvertEulerAngle180();
        if (angle <= maxVerticalAngle/ 2 &&
            angle >= -maxVerticalAngle / 2)
            playerCamera.transform.localRotation = newRotation;
    }
}
