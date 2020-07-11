using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GlobalExtension;

public class SystemController : MonoBehaviour
{
    public CameraController cameraController;
    private bool sceneChanging = false;

    void Start()
    {
        if (cameraController.NotExist())
            throw new Exception("Requered object os NULL");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            ChangeScene(Scenes.MAIN_MENU_SCENE);
        }
    }

    private void FixedUpdate()
    {
        if (sceneChanging)
            ChangeScene(Scenes.MAIN_MENU_SCENE);
    }

    public void ChangeScene(string sceneName, bool withFadeOut = true)
    {
        if (!withFadeOut)
        {
            SceneManager.LoadScene(sceneName);
            return;
        }
        if (!sceneChanging)
        {
            sceneChanging = true;
            cameraController.FadeOut();
        }
        if (!cameraController.IsFadeOutPlaying)
            SceneManager.LoadScene(sceneName);
    }
}
