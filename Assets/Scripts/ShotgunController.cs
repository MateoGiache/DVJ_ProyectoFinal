using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class ShotgunController : MonoBehaviour
{
    [SerializeField] private Animator shotgunController;
    private bool aimMotionBool;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletPoint;
    private float shootingTimer;
    private AudioSource audioShoot;
    void Start()
    {
        aimMotionBool = true;
        shootingTimer = Time.time;
        audioShoot = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (Time.time-shootingTimer)>3)
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        Instantiate(bullet, bulletPoint.position, bulletPoint.rotation);
        shotgunController.SetTrigger("shootCondition");
        shootingTimer = Time.time;
        audioShoot.Play();
    }
}
