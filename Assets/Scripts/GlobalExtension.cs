using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public static class GlobalExtension
{
    /// <summary>
    /// Write message to console.
    /// </summary>
    /// <param name="message">Message</param>
    public static void Log(string message)
    {
        Debug.Log(message);
    }
    public static void Error(string message)
    {
        Debug.LogError(message);
    }
    public static void Error<T>(T ob)
    {
        Debug.LogError(typeof(T) + " is null.");
    }


    /// <summary>
    /// Return first child Transform with tag from current scene
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="tag"></param>
    /// <returns>child Transform</returns>
    public static Transform FindChildByTag(this Scene scene, string tag)
    {
        foreach (var parent in scene.GetRootGameObjects())
        {
            var child = parent.transform.FindChildByTag(tag);
            if (child != null) { return child; }
        }
        return null;
    }

    /// <summary>
    /// Return first child Transform with tag in parent
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="tag"></param>
    /// <returns>child Transform</returns>
    public static Transform FindChildByTag(this Transform parent, string tag)
    {
        var children = parent.transform.Children();
        return children.Where(c => c.CompareTag(tag)).DefaultIfEmpty(null).FirstOrDefault();
    }

    /// <summary>
    /// Return children GameObject list from all parent hierarchy
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="tag"></param>
    /// <returns></returns>
    public static List<Transform> ChildrenList(this Transform parent)
    {
        var result = new List<Transform>();
        foreach (Transform transform in parent)
        {
            result.Add(transform);
            if (transform.childCount > 0)
                result.AddRange(transform.ChildrenList());
        }
        return result;
    }

    /// <summary>
    /// Return children GameObject as IEnumerable from all parent hierarchy
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="tag"></param>
    /// <returns>Children IEnumerable of Transform</returns>
    public static IEnumerable<Transform> Children(this Transform parent)
    {
        foreach (Transform transform in parent)
        {
            yield return transform;
            if (transform.childCount > 0)
                foreach (var item in transform.Children())
                    yield return item;
        }
    }

    /// <summary>
    /// Return children Transform with tag. 
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="tag"></param>
    /// <param name="onlyActive">Take only active</param>
    /// <returns>List of Transform</returns>
    public static List<Transform> FindChildrenByTag(this GameObject parent, string tag, bool onlyActive = false)
    {
        var children = parent.transform.Children();
        if (onlyActive)
            return children.Where(c => c.CompareTag(tag) & c.gameObject.activeSelf).ToList();
        else
            return children.Where(c => c.CompareTag(tag)).ToList();
    }

    /// <summary>
    /// Check is null or destroyed current object and return bool.
    /// </summary>
    /// <param name="obj"></param>
    /// <returns>bool</returns>
    public static bool NotExist(this object obj)
    {
        if (obj is IComponent)
            return (obj as IComponent).isDestroyed;
        else if (obj is Component)
            return (obj as Component) == null;
        else
            return obj == null;
    }

    /// <summary>
    /// Check is null or destroyed current object and log error to console.
    /// </summary>
    /// <param name="obj"></param>
    public static void CheckExist(this object obj)
    {
        if (obj.NotExist()) Error(obj);
    }

    /// <summary>
    /// Return parent GameObject with tag.
    /// </summary>
    /// <param name="childObject"></param>
    /// <param name="tag"></param>
    /// <returns>parent GameObject or null on failed.</returns>
    public static GameObject FindParentByTag(this GameObject childObject, string tag)
    {
        Transform t = childObject.transform;
        while (t.parent != null)
        {
            if (t.parent.tag == tag)
            {
                return t.parent.gameObject;
            }
            t = t.parent.transform;
        }
        return null;
    }

    interface IComponent
    {
        GameObject gameObject { get; }
        Transform transform { get; }
        Component component { get; }
        bool isDestroyed { get; }
    }

    public static void QuitGame()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
         Application.Quit();
    #endif
    }

    public static class Effects
    {
        //public static void FadeInScene(this Camera camera)
        //{
        //    var frame = camera.gameObject.FindChildByTag(Tags.CAMERA_EFFECT);
        //    frame.
        //}
    }

}
