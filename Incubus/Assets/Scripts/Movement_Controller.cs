using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement_Controller : MonoBehaviour
{
    public enum PlayerState { walk, dash, attack };
    public PlayerState state = PlayerState.walk;

    public KeyCode rightKey;
    public KeyCode leftKey;
    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode dashKey;

    public float speed;
    float dashcount = 10;

    public float maxHealth;
    public float curHealth;

    Vector3 moveDirection = Vector3.zero;

    Rigidbody2D rb;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (state == PlayerState.dash)
        {
           
            dashcount--;
            //moveDirection.x *= 0.55f;
            //moveDirection.y *= 0.55f;
            /* Vector2 mov = moveDirection;
             mov *= 0.5f;
             moveDirection = mov;*/
            //moveDirection.y *= 0.5f;
          
            if (dashcount <= 0)
                state = PlayerState.walk;
        }
        if (state == PlayerState.walk)
        {
            DashCheck();
            moveDirection.x *= 0.8f;
            moveDirection.y *= 0.8f;
            if (Input.GetKey(rightKey))
            {
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
        }
        
    }

    void FixedUpdate()
    {
        Vector2 pos = transform.position + (moveDirection * DashMod(speed) * Time.deltaTime);
        rb.MovePosition(pos);
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
}
