using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    [SerializeField] private Rigidbody bullet;
    [SerializeField] private float forceToAdd;
    private float destroyTimer;
    void Start()
    {
        destroyTimer= Time.time;
    }
    void Update()
    {
        bullet.AddForce(transform.right * forceToAdd, ForceMode.Impulse);
        if((Time.time-destroyTimer)>8)
        {
            Destroy(gameObject);
        }
    }
}
