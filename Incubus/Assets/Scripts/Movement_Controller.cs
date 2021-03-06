﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement_Controller : MonoBehaviour
{
    public GameObject aim;
    
    public AudioClip shoot;
    
    public AudioClip step;
    AudioSource walk;
    Animator animator;
    bool walking;

    public enum PlayerState { walk, dash };
    public PlayerState state = PlayerState.walk;

    public GameObject manager;
    GameManager manager_script;

    public KeyCode rightKey;
    public KeyCode leftKey;
    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode dashKey;

    public float speed;
    float dashcount = 10;

    public float maxHealth;

    public GameObject bullet;

    Vector3 moveDirection = Vector3.zero;

    Rigidbody2D rb;

    void Start()
    {
        walking = false;
        
        animator = GetComponent<Animator>();
        manager = GameObject.Find("GameManager");
        manager_script = manager.GetComponent<GameManager>();
        DontDestroyOnLoad(gameObject);
        rb = GetComponent<Rigidbody2D>();
        manager_script.playerHealth = maxHealth;

        //Instantiate(aim,gameObject.transform);
    }

    void Update()
    {
        PlayerAnimate();
        manager_script.playerPos = transform.position;

        if (state == PlayerState.walk)
        {
            DashCheck();
            moveDirection.x *= 0.8f;
            moveDirection.y *= 0.8f;
            if (Input.GetKey(rightKey))
            {
                WalkSound();
                moveDirection.z = 2;
                moveDirection += Vector3.right;
                if (Input.GetKey(leftKey))
                {

                }
                if (Input.GetKey(upKey))
                {
                    moveDirection.z = 21;
                }
                if (Input.GetKey(downKey))
                {
                    moveDirection.z = 23;
                }
            }
            if (Input.GetKey(leftKey))
            {
                WalkSound();
                moveDirection.z = 4;
                moveDirection += Vector3.left;
                if (Input.GetKey(rightKey))
                {

                }
                if (Input.GetKey(upKey))
                {
                    moveDirection.z = 41;
                }
                if (Input.GetKey(downKey))
                {
                    moveDirection.z = 43;
                }
            }
            if (Input.GetKey(upKey))
            {
                WalkSound();
                moveDirection.z = 1;
                moveDirection += Vector3.up;
                if (Input.GetKey(leftKey))
                {
                    moveDirection.z = 14;
                }
                if (Input.GetKey(downKey))
                {

                }
                if (Input.GetKey(rightKey))
                {
                    moveDirection.z = 12;
                }
            }
            if (Input.GetKey(downKey))
            {
                WalkSound();
                moveDirection.z = 3;
                moveDirection += Vector3.down;
                if (Input.GetKey(leftKey))
                {
                    moveDirection.z = 34;
                }
                if (Input.GetKey(upKey))
                {

                }
                if (Input.GetKey(rightKey))
                {
                    moveDirection.z = 32;
                }
            }
            DashCheck();
        }

        if (manager_script.playerHealth <= 0)
        {
            walk.Stop();
            manager_script.GameOver = true;
            Destroy(gameObject);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                sound.me.PlaySound(shoot, .2f, Random.Range(.5f, 1));
                Debug.Log("shoot");
                Instantiate(bullet);
            }
            if (SceneManager.GetActiveScene().buildIndex == 3 && manager_script.InBed == true)
            {
                animator.SetInteger("Player State", 0);
            }
        }

        if (!(Input.GetKey(rightKey) || Input.GetKey(leftKey) || Input.GetKey(upKey) || Input.GetKey(downKey)) && walking == true)
        {
            if (walk.volume > 0.1f)
            {
                walk.volume += (0 - walk.volume) * 0.1f;
            }
            else
            {
                Debug.Log("Sound Stopped");
                walk.Stop();
                walking = false;
            }
        }

        
    }
    
    void WalkSound()
    {
        if (walking == false && SceneManager.GetActiveScene().buildIndex == 1)
        { 
            walk = sound.me.PlaySound(step, .2f, Random.Range(.7f, 1), true);
            walking = true;
        }
    }

    void FixedUpdate()
    {
        if (state == PlayerState.dash)
        {

            dashcount--;
            if (dashcount <= 0)
                state = PlayerState.walk;
        }

        Vector2 pos = transform.position + (moveDirection * DashMod(speed) * Time.deltaTime);
            rb.MovePosition(pos);       
    }

    void PlayerAnimate() {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (moveDirection.x < 1 && moveDirection.x > -1)
            {
                moveDirection.x = 0;
            }
            if (moveDirection.x < 0)
            {
                animator.SetInteger("Player State", 1);
            }
            if (moveDirection.x > 0)
            {
                animator.SetInteger("Player State", 2);
            }
            if (moveDirection.x == 0)
            {
                animator.SetInteger("Player State", 0);
            }
        }
    }

    void DashCheck()
    {
        if (Input.GetKeyDown(dashKey))
        {
            dashcount = 10;
            state = PlayerState.dash;
            Vector3 pre = moveDirection;
            if (moveDirection.z == 2)
            {
                moveDirection = Vector3.right*5;
            }
            if (moveDirection.z == 23)
            {
                pre = new Vector3(1, -1, 0);
                pre.Normalize();
                moveDirection = pre*5;
            }
            if (moveDirection.z == 21)
            {
                pre = new Vector3(1, 1, 0);
                pre.Normalize();
                moveDirection = pre * 5;
            }
            if (moveDirection.z == 4)
            {
                moveDirection = Vector3.left * 5;
            }
            if (moveDirection.z == 43)
            {
                pre = new Vector3(-1, -1, 0);
                pre.Normalize();
                moveDirection = pre * 5;
            }
            if (moveDirection.z == 41)
            {
                pre = new Vector3(-1, 1, 0);
                pre.Normalize();
                moveDirection = pre * 5;
            }
            if (moveDirection.z == 1)
            {
                moveDirection = Vector3.up * 5;
            }
            if (moveDirection.z == 12)
            {
                pre = new Vector3(1, 1, 0);
                pre.Normalize();
                moveDirection = pre * 5;
            }
            if (moveDirection.z == 14)
            {
                pre = new Vector3(-1, 1, 0);
                pre.Normalize();
                moveDirection = pre * 5;
            }
            if (moveDirection.z == 3)
            {
                moveDirection = Vector3.down * 5;
            }
            if (moveDirection.z == 34)
            {
                pre = new Vector3(-1, -1, 0);
                pre.Normalize();
                moveDirection = pre * 5;
            }
            if (moveDirection.z == 32)
            {
                pre = new Vector3(1, -1, 0);
                pre.Normalize();
                moveDirection = pre * 5;
            }
        }
    }

    float DashMod(float speed)
    {
        float s = speed;
        if (state == PlayerState.dash)
            s *= 3f;
        return s;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == GameObject.FindGameObjectWithTag("Enemy").tag || collision.gameObject.tag == GameObject.FindGameObjectWithTag("EnemyBullet").tag)
        {
            manager_script.TakeDamage(1);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collide");
        if(collision.tag == "EnemyBullet" || collision.tag == "Enemy")
        {
            manager_script.TakeDamage(1);
        }
        if(collision.tag == "bed")
        {
            manager_script.InBed = true;
        }
        if (collision.tag == "Health")
        {
            Destroy(collision.gameObject);
            manager_script.playerHealth += 1;
            sound.me.PlaySound(manager_script.healthNoise, .5f, 1);

        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "bed")
        {
            manager_script.InBed = false;
        }
    }
}
