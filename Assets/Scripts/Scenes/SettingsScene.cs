using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Back()
    {
        var systemController = GameObject.Find("Controllers");
        systemController.GetComponent<SystemController>().ChangeScene(Scenes.MAIN_MENU_SCENE);
    }
}
