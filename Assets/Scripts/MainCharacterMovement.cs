using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
using static UnityEngine.GridBrushBase;

public class MainCharacterMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private float mainCharacterHealth;
    private float zombieDamage = 20;
    private AudioSource audioWalking;
    private bool characterIsAlive;
    private void Start()
    {
        mainCharacterHealth = 100;
        Debug.Log("Movimiento: ASDW || Rotación: Flechas ◄ y ► || Linterna: F || Disparo: Space || Camara: C");
        audioWalking = GetComponent<AudioSource>();
        characterIsAlive = true;
    }
    void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        if (characterIsAlive) {
            Move(horizontal, vertical, speed);
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(0, -2, 0, Space.Self);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(0, 2, 0, Space.Self);
            }
        }
        if(horizontal==0 && vertical==0)
        {
            audioWalking.volume=Mathf.Lerp(1,0,2);
        }
        else
        {
            audioWalking.volume = Mathf.Lerp(0, 1, 2);
        }
        if (mainCharacterHealth <= 0)
        {
            Debug.Log("Oh, no! Parece que las heridas son demasiado profundas");
            characterIsAlive = false;
        }
    }
    private void Move(float horizontal, float vertical,float speed)
    {
        transform.position += (transform.right*horizontal*(speed*Time.deltaTime)) + (transform.forward*vertical*(speed*Time.deltaTime));
    }
    public void LooseHealth()
    {
        mainCharacterHealth = mainCharacterHealth - zombieDamage;
    }
}