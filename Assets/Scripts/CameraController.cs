using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GlobalExtension;

public class CameraController : MonoBehaviour
{
    public bool fadeInEffect = true;
    private Animation cameraFadeAnimation;
    public bool IsFadeOutPlaying { get { return cameraFadeAnimation.IsPlaying("FadeOut"); } }
    public bool IsFadeInPlaying { get { return cameraFadeAnimation.IsPlaying("FadeIn"); } }
    void Start()
    {
        cameraFadeAnimation = transform.FindChildByTag(Tags.CAMERA_EFFECT).GetComponent<Animation>();
        if (cameraFadeAnimation.NotExist())
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
        cameraFadeAnimation.Play("FadeIn");
    }

    public void FadeOut()
    {
        cameraFadeAnimation.Play("FadeOut");
    }
}
