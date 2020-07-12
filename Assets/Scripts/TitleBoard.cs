using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBoard : MonoBehaviour
{
    [SerializeField]
    enum ActionName { NewGame, Credits, Exit}

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(Tags.THROW_THING))
        {

        }
    }
}
