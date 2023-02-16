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
    [SerializeField] private LayerMask toCollideWith;
    private float raycastDistance = 50f;
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
            ShootComplement();
            ShootRayCast(); 
        }
    }
    private void ShootRayCast()
    {
        var hasCollided = Physics.Raycast(bulletPoint.position,bulletPoint.forward,out RaycastHit raycastInfo, raycastDistance, toCollideWith);
        if(hasCollided)
        {
            var zombieCollided = raycastInfo.collider;
            zombieCollided.GetComponent<ZombieController>().HitByTheBullet();
        }
    }
    private void ShootComplement()
    {
        shotgunController.SetTrigger("shootCondition");
        shootingTimer = Time.time;
        audioShoot.Play();
    }
}
