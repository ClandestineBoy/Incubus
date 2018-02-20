using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Controller : MonoBehaviour {

    public GameObject player;

    Vector2 anchor;

    public float speed;
    Vector3 moveDirection;

    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
        anchor = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        moveDirection = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y);

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
        if(collision.gameObject.tag != GameObject.FindGameObjectWithTag("Player").tag)
        Destroy(gameObject);  
    }
}
