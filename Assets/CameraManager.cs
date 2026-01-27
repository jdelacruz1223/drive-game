using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private GameObject currentCamWaypoint;
    [SerializeField] private GameObject[] camWaypoints;
    [SerializeField] private int camIndex;
    private bool readyToSwitch = true;
    private Camera cam;
    private int camCount;
    
    void Start()
    {
        // print(camera.name);
        cam = Camera.main;
        camCount = camWaypoints.Length;
        camIndex = 0;
        currentCamWaypoint = camWaypoints[camIndex];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && readyToSwitch)
        {
            Debug.Log("Switch Cam");
            StartCoroutine(SwitchCamCoroutine());
        }
    }

    IEnumerator SwitchCamCoroutine()
    {
        readyToSwitch = false;
        camIndex = (camIndex + 1) % camCount;
        currentCamWaypoint = camWaypoints[camIndex];
        cam.transform.position = currentCamWaypoint.transform.position;
        cam.transform.rotation = currentCamWaypoint.transform.rotation;
        readyToSwitch = true;
        yield return null;
    }
}
