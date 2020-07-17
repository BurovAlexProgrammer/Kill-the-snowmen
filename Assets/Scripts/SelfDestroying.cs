using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static GlobalExtension;

public class SelfDestroying : MonoBehaviour
{
    [Header("Destroy this GameObject after when animation ended otherwise lifetime ended")]
    [SerializeField]
    float lifeTime = 3;
    Animation destroyAnimation;
    enum Mode {afterAnimation, lifetimeEnded }
    Mode currMode = Mode.afterAnimation;

    void Start()
    {
        if (GetComponent<Animation>().Exist())
        {
            destroyAnimation = GetComponent<Animation>();
            if (!destroyAnimation.isPlaying)
                destroyAnimation.Play();
        } else
        {
            currMode = Mode.lifetimeEnded;
        }
    }

    private void FixedUpdate()
    {
        if (currMode == Mode.lifetimeEnded)
        {
            lifeTime -= Time.deltaTime;
            if (lifeTime <= 0) 
                Destroy(gameObject);
        }
        if (currMode == Mode.afterAnimation)
            if (!destroyAnimation.isPlaying)
                Destroy(gameObject);
    }
}
