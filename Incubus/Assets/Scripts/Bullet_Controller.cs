using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Controller : MonoBehaviour {

    public GameObject player;

    public Vector2 anchor;

    Vector2 moveDirection;

	// Use this for initialization
	void Start () {
        transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
        anchor = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }
	
	// Update is called once per frame
	void Update () {
        
        
    }
    void FixedUpdate()
    {
        Vector2 pos;
        if (transform.position.x < anchor.x)
        {
            moveDirection = Vector2.right;
        }
        if (transform.position.x > anchor.x)
        {
            moveDirection = Vector2.left;
        }
        pos = transform.position;
        pos += moveDirection;
        transform.position = pos;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);  
    }
}
