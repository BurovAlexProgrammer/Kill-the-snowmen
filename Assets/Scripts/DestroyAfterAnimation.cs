using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Depricated. Use SelfDestroying instead.
/// </summary>
public class DestroyAfterAnimation : MonoBehaviour
{
    private Animation anim; 
    void Start()
    {
        //Check requered objects
        anim = GetComponent<Animation>();
        if (anim == null)
            throw new Exception("Requered Animation");
        if (anim.GetClipCount() == 0)
            throw new Exception("No clips in Animation");
        if (anim.playAutomatically == false)
            throw new Exception("Animation.playAutomatically == false");
    }

    private void FixedUpdate()
    {
        if (!anim.isPlaying)
            Destroy(gameObject);
    }
}
