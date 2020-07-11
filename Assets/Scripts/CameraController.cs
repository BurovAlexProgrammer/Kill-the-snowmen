using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GlobalExtension;

public class CameraController : MonoBehaviour
{
    public Camera camera;
    public bool fadeInEffect = true;
    public GameObject fadeFrame;
    private Animation fadeAnimation;
    public bool IsFadeOutPlaying { get { return fadeAnimation.IsPlaying("FadeOut"); } }
    public bool IsFadeInPlaying { get { return fadeAnimation.IsPlaying("FadeIn"); } }
    void Start()
    {
        fadeAnimation = fadeFrame.GetComponent<Animation>();
        if (camera.NotExist())
            throw new Exception("Requered object os NULL");
        if (fadeFrame.NotExist())
            throw new Exception("Requered object os NULL");
        if (fadeAnimation.NotExist())
            throw new Exception("Requered object os NULL");
        if (fadeInEffect)
            FadeIn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FadeIn()
    {
        fadeAnimation.Play("FadeIn");
    }

    public void FadeOut()
    {
        fadeAnimation.Play("FadeOut");
    }
}
