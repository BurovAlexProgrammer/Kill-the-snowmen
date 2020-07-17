using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GlobalExtension;

public class InputController : MonoBehaviour
{
    SystemController systemController;
    CameraController cameraController;
    void Start()
    {
        systemController = GetComponent<SystemController>();
        cameraController = GetComponent<CameraController>();
        if (systemController.NotExist())
            Error("SystemController not found.");
        if (cameraController.NotExist())
            Error("CameraController not found.");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            systemController.Pause();
        } 
    }

    
}
