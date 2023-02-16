using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieTrigger : MonoBehaviour
{
    private AudioSource AudioZombieTrigger;
    private bool triggerTrigger;
    void Start()
    {
        AudioZombieTrigger = GetComponent<AudioSource>();
        triggerTrigger = true;
    }
    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCharacter") && triggerTrigger)
        {
            AudioZombieTrigger.Play();
            triggerTrigger= false;
            Debug.Log("Escuchas eso?");
        }
    }
}
