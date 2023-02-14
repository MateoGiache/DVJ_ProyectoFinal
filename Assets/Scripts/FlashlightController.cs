using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    [SerializeField] private Light flashlight;
    private bool switchFlashlight;
    private AudioSource audioFlashlight;
    void Start()
    {
        switchFlashlight = false;
        TurnOffFlashlight();
        audioFlashlight = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            audioFlashlight.Play();
            switch(switchFlashlight){
                case true:
                    TurnOnFlashlight();
                    break;
                case false:
                    TurnOffFlashlight();
                    break;
            }
        }
    }
    private void TurnOnFlashlight()
    {
        flashlight.intensity = 15;
        switchFlashlight = !switchFlashlight;
    }
    private void TurnOffFlashlight()
    {
        flashlight.intensity = 0;
        switchFlashlight = !switchFlashlight;
    }
}