using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GlobalExtension;

/// <summary>
/// 3D button that execute action on throwThing collision with this board.
/// </summary>
public class TitleBoard : MonoBehaviour
{
    enum ActionNames {None, NewGame, Credits, Exit, Settings}
    [SerializeField]
    ActionNames actionName = ActionNames.None;
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
    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag(Tags.THROW_THING)) return;
        switch (actionName)
        {
            case ActionNames.NewGame:
                systemController.ChangeScene(Scenes.GAME_SCENE);
                break;
            case ActionNames.Credits:
                systemController.ChangeScene(Scenes.CREDITS_SCENE);
                break;
            case ActionNames.Settings:
                systemController.ChangeScene(Scenes.SETTINGS_SCENE);
                break;
            case ActionNames.Exit:
                //TODO A u sure exit?
                QuitGame();
                break;
        }
    }
}
