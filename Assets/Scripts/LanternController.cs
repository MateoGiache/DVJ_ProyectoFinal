using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternController : MonoBehaviour
{
    [SerializeField] private Light lanternLight;
    void Update()
    {
        lanternLight.intensity = Mathf.PingPong(Time.time,1) ;
    }
}
