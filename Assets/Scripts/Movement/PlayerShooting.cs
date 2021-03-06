﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField]
    Transform spawnPos;

    public GameObject weapon;
    public GameObject player;

    public float lastTimeFired = 0;
    public AudioSource aS;

    [SerializeField]
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        if (spawnPos == null)
            spawnPos = transform.GetChild(0);

        player = transform.parent.gameObject;
        aS = this.GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        //Darf geschossen werden?
        shoot();
    }

    void shoot()
    {
        bool didFire = false;
        bool faster = false;
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.Play("BeeTop");
            player.GetComponent<SpriteRenderer>().flipX = false;
            didFire = true;

            if (Input.GetKey(KeyCode.W))
                faster = true;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
            animator.Play("BeeDown");
            player.GetComponent<SpriteRenderer>().flipX = false;
            didFire = true;

            if (Input.GetKey(KeyCode.S))
                faster = true;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
            animator.Play("Bee_Floating");
            player.GetComponent<SpriteRenderer>().flipX = false;
            didFire = true;

            if (Input.GetKey(KeyCode.D))
                faster = true;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
            animator.Play("Bee_Floating");
            player.GetComponent<SpriteRenderer>().flipX = true;
            didFire = true;

            if (Input.GetKey(KeyCode.A))
                faster = true;
        }

        //abfrage an shooting speed
       if (didFire && Time.time - lastTimeFired > StatManager.StatManagerInstance.GetFireRate())
        {
            GameObject honey = Instantiate(weapon, spawnPos.position, Quaternion.identity); //projectile shoot
            if (!aS.isPlaying)
            {
                aS.Play();
            }
            if (faster)
            {
                honey.GetComponent<HoneyMovement>().mvtVec = transform.up*2; //set facing direction
            }
            else
            {
                honey.GetComponent<HoneyMovement>().mvtVec = transform.up; //set facing direction
            }
           // honey.GetComponent<HoneyMovement>().mvtVec = transform.up; //set facing direction
           // honey.GetComponent<Rigidbody2D>().velocity = player.GetComponent<Rigidbody2D>().velocity; //give velocity on the way in order to spawn honey before player
            
            lastTimeFired = Time.time;
        }

    }
}
