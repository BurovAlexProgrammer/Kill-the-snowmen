using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    GameObject targetObject = default;

    public GameObject GetTarget()
    {
        return targetObject;
    }

    public void SetTarget(GameObject gameObject)
    {
        targetObject = gameObject;
    }
}
