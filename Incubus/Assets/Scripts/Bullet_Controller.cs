using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Controller : MonoBehaviour {

    public GameObject player;

    Vector2 anchor;

    public float speed;
    public float damage;
    Vector3 moveDirection;

    Rigidbody2D rb;

	// Use this for initialization
 
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        if (gameObject.tag != "EnemyBullet")
        {
            transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
            anchor = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else
        {
            //transform.position = GameObject.FindGameObjectWithTag("Enemy").transform.position;
            anchor = GameObject.FindGameObjectWithTag("Player").transform.position;
        }
        moveDirection = new Vector2(anchor.x - transform.position.x, anchor.y - transform.position.y);
    }
	
	// Update is called once per frame
	void Update () {
        moveDirection.x *= 0.8f;
        moveDirection.y *= 0.8f;
        moveDirection.Normalize();
    }
    void FixedUpdate()
    {
        Vector2 pos;
        pos = transform.position + (moveDirection * speed * Time.deltaTime);
        rb.MovePosition(pos);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "Bullet")
        {
            if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "Bullet" && collision.gameObject.tag != "EnemyBullet")
            {
                Destroy(gameObject);
            }
        }
        if(gameObject.tag == "EnemyBullet")
        {
            if (collision.gameObject.tag != "Enemy" && collision.gameObject.tag != "Bullet" && collision.gameObject.tag != "EnemyBullet")
            {
                Destroy(gameObject);
            }
        }
    }
}
