using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GlobalExtension;

public class InputController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            var scene = SceneManager.GetActiveScene();
            //var gs = scene.GetRootGameObjects();
            //var g2 = gs.Where(g => g.CompareTag(Tags.CAMERA_EFFECT));
            //g2?.First()?.GetComponent<Animator>().SetBool("FadeOut", true);
            //gameObject.Tag
            //var sr = scene.FindChildByTag(Tags.CAMERA_EFFECT);
            //sr.GetComponent<Animator>().SetBool("FadeOut", true);
            var list = new List<int>() { 1,2,34,5,7};
            var re = list.Where(l => l == 0)?.FirstOrDefault();

            var c = Camera.main.transform.Children();
            var c2 = Camera.main.transform.Children().ToList();
        }
    }

    
}
