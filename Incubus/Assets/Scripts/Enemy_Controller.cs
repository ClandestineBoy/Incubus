using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour {

    // Use this for initialization
    Rigidbody2D rb;
    Vector3 moveDirection;
    public float speed;
    public bool chase;
    public bool shoot;

    public float maxhp;
    public float hp;

	void Start () {
       hp = maxhp;
       rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        moveDirection.x *= 0.8f;
        moveDirection.y *= 0.8f;

        if(chase == true)
        moveDirection = new Vector2(GameObject.FindGameObjectWithTag("Player").transform.position.x - transform.position.x, GameObject.FindGameObjectWithTag("Player").transform.position.y - transform.position.y); 

        moveDirection.Normalize();

        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {
        Vector3 pos;
        pos = transform.position + (moveDirection * speed * Time.deltaTime);
        rb.MovePosition(pos);
    }
    void TakeDamge(float damage)
    {
        hp -= damage;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == GameObject.FindGameObjectWithTag("Bullet").tag)
        {
            hp -= 1;
        }
    }
    }
