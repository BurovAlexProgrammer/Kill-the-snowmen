using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GlobalExtension;

public class SceneCredits : MonoBehaviour
{
    GameObject systemControllerGameObject;
    SystemController systemController;


    void Start()
    {
        //Check requered objects
        systemControllerGameObject = GameObject.Find("Controllers");
        systemController = systemControllerGameObject.GetComponent<SystemController>();
        if (systemControllerGameObject == null)
            throw new Exception("systemController is null");
        if (systemController == null)
            throw new Exception("systemController is null");
        if (systemController == null)
            throw new Exception("systemController is null");
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            systemController.ChangeScene(Scenes.MAIN_MENU_SCENE);
    }

    private void FixedUpdate()
    {

    }

    public void GotoMainMenu()
    {
        systemController.ChangeScene(Scenes.MAIN_MENU_SCENE);
    }
}
