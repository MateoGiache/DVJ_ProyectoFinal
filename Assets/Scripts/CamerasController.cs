using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerasController : MonoBehaviour
{
    [SerializeField] private GameObject cameraNormalState;
    [SerializeField] private GameObject cameraAimState;
    private bool switchCamera;
    void Start()
    {
        switchCamera = true;
        TurnOnCamera(cameraNormalState, cameraAimState);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            switch (switchCamera)
            {
                case true:
                    TurnOnCamera(cameraNormalState, cameraAimState);
                    break;
                case false:
                    TurnOnCamera(cameraAimState, cameraNormalState);
                    break;
            }
        }
    }
    private void TurnOnCamera(GameObject cameraToTurnOn, GameObject cameraToTurnOff)
    {
        cameraToTurnOn.SetActive(true);
        cameraToTurnOff.SetActive(false);
        switchCamera = !switchCamera;
    }
}
