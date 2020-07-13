using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GlobalExtension;

/// <summary>
/// Control: 
///  - scene changing
/// </summary>
public class SystemController : MonoBehaviour
{
    public CameraController cameraController;
    private bool sceneChanging = false;
    private string nextSceneName = "";

    void Start()
    {
        cameraController = GetComponent<CameraController>();
        //Check requered objects
        if (cameraController.NotExist())
            throw new Exception("Requered object os NULL");
        
    }

    private void FixedUpdate()
    {
        if (sceneChanging)
            ChangeScene(nextSceneName);
    }

    /// <summary>
    /// Change scene with fade out effect optional
    /// </summary>
    /// <param name="sceneName">Target scane name</param>
    /// <param name="withFadeOut">Turn on fade out animation</param>
    public void ChangeScene(string sceneName, bool withFadeOut = true)
    {
        nextSceneName = sceneName;
        if (!withFadeOut)
        {
            SceneManager.LoadScene(nextSceneName);
            return;
        }
        if (!sceneChanging)
        {
            sceneChanging = true;
            cameraController.FadeOut();
        }
        if (!cameraController.IsFadeOutPlaying)
            SceneManager.LoadScene(nextSceneName);
    }
}
