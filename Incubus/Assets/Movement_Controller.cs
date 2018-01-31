using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Controller : MonoBehaviour {

    public KeyCode rightKey;
    public KeyCode leftKey;
    public KeyCode upKey;
    public KeyCode downKey;

    public float speed;

    Vector2 moveDirection = Vector2.zero;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        moveDirection *= 0.8f;

        if (Input.GetKey(rightKey))
        {
            moveDirection += Vector2.right;
        }
        if (Input.GetKey(leftKey))
        {
            moveDirection += Vector2.left;
        }
        if (Input.GetKey(upKey))
        {
            moveDirection += Vector2.up;
        }
        if (Input.GetKey(downKey))
        {
            moveDirection += Vector2.down;
        }
        if(transform.position.x > 9.5f)
        {
            Vector3 pos = transform.position;
            pos.x = -9.3f;
            transform.position = pos;
        }
        if (transform.position.x < -9.5f)
        {
            Vector3 pos = transform.position;
            pos.x = 9.3f;
            transform.position = pos;
        }
    }

    void FixedUpdate()
    {
        Vector2 pos = (Vector2)transform.position + (moveDirection * speed * Time.deltaTime);
        rb.MovePosition(pos);
    }
}
