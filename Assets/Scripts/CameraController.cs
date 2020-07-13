using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] 
    bool fadeInEffect = true;
    [SerializeField]
    GameObject fadeFrame = null;
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

    private void FixedUpdate()
    {
        //Turn off FadeFrame after animation
        if (fadeInEffect)
        {
            if (!fadeAnimation.isPlaying)
            {
                fadeInEffect = false;
                fadeFrame.SetActive(false);
            }
        }
    }

    /// <summary>
    /// Animate fade in scene effect
    /// </summary>
    void FadeIn()
    {
        fadeFrame.SetActive(true);
        fadeAnimation.Play("FadeIn");
    }

    /// <summary>
    /// Animate fade out scene effect
    /// </summary>
    public void FadeOut()
    {
        fadeFrame.SetActive(true);
        fadeAnimation.Play("FadeOut");
    }
}
