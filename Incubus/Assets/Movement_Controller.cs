using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Controller : MonoBehaviour
{
    public enum PlayerState { walk, dash, attack};
    public PlayerState state = PlayerState.walk;

    public KeyCode rightKey;
    public KeyCode leftKey;
    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode dashKey;

    public float speed;
    float dashcount = 20;

    Vector3 moveDirection = Vector3.zero;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if(state == PlayerState.dash)
        {
            dashcount--;
            moveDirection *= 0.8f;
            if (moveDirection.z == 1)
            {
                moveDirection += Vector3.right;
            }
            if (moveDirection.z == 3)
            {
                moveDirection += Vector3.left;
            }
            if (moveDirection.z == 0)
            {
                moveDirection += Vector3.up;
            }
            if (moveDirection.z == 2)
            {
                moveDirection += Vector3.down;
            }
            if (dashcount <= 0)
                state = PlayerState.walk;
        }
        if (state == PlayerState.walk)
        {
            moveDirection *= 0.75f;
            if (Input.GetKey(rightKey))
            {
                moveDirection += Vector3.right;
                moveDirection.z = 1;
            }
            if (Input.GetKey(leftKey))
            {
                moveDirection += Vector3.left;
                moveDirection.z = 3;
            }
            if (Input.GetKey(upKey))
            {
                moveDirection += Vector3.up;
                moveDirection.z = 0;
            }
            if (Input.GetKey(downKey))
            {
                moveDirection += Vector3.down;
                moveDirection.z = 2;
            }
            DashCheck();
        }
        Wrap();
    }

    void FixedUpdate()
    {
        Vector2 pos = transform.position + (moveDirection * DashMod(speed) * Time.deltaTime);
        rb.MovePosition(pos);
    }

    void Wrap()
    {
        if (transform.position.x > 9.5f)
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
        if (transform.position.y > 5.7f)
        {
            Vector3 pos = transform.position;
            pos.y = -5.5f;
            transform.position = pos;
        }
        if (transform.position.y < -5.7f)
        {
            Vector3 pos = transform.position;
            pos.y = 5.5f;
            transform.position = pos;
        }
    }

    void DashCheck()
    {
        if (Input.GetKeyDown(dashKey))
        {
            dashcount = 20;
            state = PlayerState.dash;
        }
    }
    float DashMod(float speed)
    {
        float s = speed;
        if (state == PlayerState.dash)
            s *=6;
        return s;
    }
}
