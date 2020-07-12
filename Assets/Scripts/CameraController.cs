using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] 
    bool fadeInEffect = true;
    [SerializeField]
    GameObject fadeFrame;
    private Animation fadeAnimation;
    public bool IsFadeOutPlaying { get { return fadeAnimation.IsPlaying("FadeOut"); } }
    public bool IsFadeInPlaying { get { return fadeAnimation.IsPlaying("FadeIn"); } }
    void Start()
    {
        //Check requered objects
        fadeAnimation = fadeFrame.GetComponent<Animation>();
        if (fadeFrame.NotExist())
            throw new Exception("Requered object os NULL");
        if (fadeAnimation.NotExist())
            throw new Exception("Requered object os NULL");
        //FadeIn scene effect
        if (fadeInEffect)
            FadeIn();
    }

    void Update()
    {
        
    }

    /// <summary>
    /// Animate fade in scene effect
    /// </summary>
    void FadeIn()
    {
        fadeAnimation.Play("FadeIn");
    }

    /// <summary>
    /// Animate fade out scene effect
    /// </summary>
    public void FadeOut()
    {
        fadeAnimation.Play("FadeOut");
    }
}
