using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    [SerializeField] private Animator ZombieAnimatorController;
    private bool followMotionTrigger, walkTrigger;
    private float walkTimer;
    [SerializeField] private Transform mainCharacter;
    private float speed = 0.6f;
    private float bulletDamage = 105;
    [SerializeField] private float zombieHealth;
    private float zombieCollisionTimer;
    private AudioSource AudioZombieWalk;
    void Start()
    {
        zombieCollisionTimer = Time.time;
        AudioZombieWalk = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (walkTrigger && (Time.time - walkTimer > 5))
        {
            zombieWalk();
        }

        if (zombieHealth<0)
        {
            zombieFall();
        }
    }
    public void zombieStart()
    {
        ZombieAnimatorController.SetBool("StartMotion", true);
        walkTrigger = true;
        walkTimer = Time.time;
        followMotionTrigger = true;
    }
    public void zombieWalk()
    {
        if (followMotionTrigger)
        {
            ZombieAnimatorController.SetBool("FollowMotion", true);
            followMotionTrigger = false;
        }
        Vector3 maincharacterPosition = mainCharacter.position;
        Vector3 vectorToCharacter = mainCharacter.position - transform.position;
        vectorToCharacter.y = 0;
        transform.rotation = Quaternion.LookRotation(vectorToCharacter);
        transform.position += vectorToCharacter.normalized * (speed * Time.deltaTime);
        AudioZombieWalk.enabled=true;
    }
    public void zombieFall()
    {
        ZombieAnimatorController.SetBool("FallMotion", true);
        walkTrigger = false;
        AudioZombieWalk.enabled=false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            zombieHealth -= bulletDamage;
            Debug.Log("Lo mataste!");
            GetComponent<Rigidbody>().isKinematic=true;
        }
        if (other.CompareTag("MainCharacter") && Time.time-zombieCollisionTimer>2)
        {
            zombieCollisionTimer = Time.time;
            if(zombieHealth > 0)
            {
                other.GetComponent<MainCharacterMovement>().LooseHealth();
                Debug.Log("Corre, te está mordiendo!");
            }
        }
    }
}
