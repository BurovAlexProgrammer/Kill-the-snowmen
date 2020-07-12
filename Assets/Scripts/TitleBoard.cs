using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 3D button that execute action on throwThing collision with this board.
/// </summary>
public class TitleBoard : MonoBehaviour
{
    enum ActionNames { NewGame, Credits, Exit}
    [SerializeField]
    ActionNames actionName;
    GameObject systemControllerGameObject;
    SystemController systemController;

    void Start()
    {
        //Check requered objects
        systemControllerGameObject = GameObject.Find("SystemController");
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
                systemController.ChangeScene(Scenes.GAME_SCENE);
                break;
        }
    }
}
