using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GlobalExtension;

public class SceneIntro : MonoBehaviour
{
    GameObject systemControllerGameObject;
    SystemController systemController;
    [SerializeField]
    Animation introAnimation = null;

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
        if (introAnimation == null)
            throw new Exception("Requered Animation");
        if (introAnimation.GetClipCount() == 0)
            throw new Exception("No clips in Animation");
        if (introAnimation.playAutomatically == false)
            throw new Exception("Animation.playAutomatically == false");
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
            systemController.ChangeScene(Scenes.MAIN_MENU_SCENE);
        //TODO добавить переход после проигрывания анимации
        if (!introAnimation.isPlaying)
        {
            systemController.ChangeScene(Scenes.MAIN_MENU_SCENE);
        }
    }

    private void FixedUpdate()
    {

    }
}
