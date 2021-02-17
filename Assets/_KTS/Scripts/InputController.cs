using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GlobalExtension;

public class InputController : MonoBehaviour
{
    [SerializeField]
    PlayerController player;
    [SerializeField]
    [Range(5f, 300f)]
    float mouseSensetive = 1f;
    bool looking { get { return (Input.GetAxisRaw("Mouse X")!=0 || Input.GetAxisRaw("Mouse Y") != 0); } }

    public Vector3 tempVector;
    public float tempFloat;

    SystemController systemController;
    CameraController cameraController;

    private void Awake()
    {
        systemController = GetComponent<SystemController>();
        cameraController = GetComponent<CameraController>();
        if (systemController.NotExist())
            Error("SystemController not found.");
        if (cameraController.NotExist())
            Error("CameraController not found.");
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            systemController.Pause();
        }

        if (!systemController.isPaused)
        {
            if (looking)
            {
                if (Input.GetAxisRaw("Mouse X") != 0) 
                    player.Rotate(Quaternion.Euler(new Vector3(0f, Input.GetAxis("Mouse X") * mouseSensetive * Time.deltaTime, 0f)));
                if (Input.GetAxisRaw("Mouse Y") != 0)
                    player.TiltCamera(Quaternion.Euler(new Vector3(-Input.GetAxis("Mouse Y") * mouseSensetive * Time.deltaTime, 0f, 0f)));
            }
        }
    }   
}
