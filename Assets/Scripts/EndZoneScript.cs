using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndZoneScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCharacter"))
        {
            Debug.Log("Ganase! Por ahora...");
        }
    }
}
