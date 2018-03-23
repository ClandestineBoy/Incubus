using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour {

    // Use this for initialization
    Rigidbody2D rb;
    SpriteRenderer sr;
    Vector3 moveDirection;
    public float speed;
    public bool chase;
    public bool shoot;

    Animator animator;

    public GameObject manager;
    GameManager manager_script;

    public float fireInterval;
    public float fireCount;
    public float maxhp;
    public float hp;

    public GameObject EnemyBullet;

	void Start () {
        animator = GetComponent<Animator>();
        animator.SetInteger("Alive",1);
        manager = GameObject.Find("GameManager");
        manager_script = manager.GetComponent<GameManager>();
       hp = maxhp;
       rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
       
    void FixedUpdate()
    {
            moveDirection.x *= 0.8f;
            moveDirection.y *= 0.8f;

            if (chase == true)
                Chasing();
            if (shoot == true)
                Shooting();

            if (hp <= 0)
            {
                Destroy(gameObject);
                manager_script.enemiesInRoom -= 1;
            }
            Color();

        Vector3 pos;
        pos = transform.position + (moveDirection * speed * Time.deltaTime);
        rb.MovePosition(pos);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == GameObject.FindGameObjectWithTag("Bullet").tag)
        {
            hp -= manager_script.bulletDamage;
        }
    }

    void Chasing()
    {
        moveDirection = new Vector2(GameObject.FindGameObjectWithTag("Player").transform.position.x - transform.position.x, GameObject.FindGameObjectWithTag("Player").transform.position.y - transform.position.y);

        moveDirection.Normalize();
    }
    void Shooting()
    {
        fireCount--;
        if(fireCount <= 0)
        {
            Instantiate(EnemyBullet, transform.position, Quaternion.identity);
            fireCount = fireInterval;
        }

    }

    void Color()
    {
        sr.color = new Color((hp/maxhp), (hp / maxhp), (hp / maxhp));
    }
    }
