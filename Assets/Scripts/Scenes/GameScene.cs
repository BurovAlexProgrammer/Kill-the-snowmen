using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GlobalExtension;

public class GameScene : MonoBehaviour
{
    SystemController systemController;
    void Start()
    {
        systemController = GameObject.Find("Controllers").GetComponent<SystemController>();
        systemController.Pause(false);
    }

    void Update()
    {
        
    }

    public void Back()
    {
        systemController.Pause(false);
    }

    public void ToMainMenu()
    {
        systemController.Pause(false);
        systemController.ChangeScene(Scenes.MAIN_MENU_SCENE);
    }

    public void Exit()
    {
        systemController.Pause(false);
        QuitGame();
    }
}
