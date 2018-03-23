using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour {

    public GameObject player;
    public GameObject manager;
    GameManager manager_script;

    void Start () {
        manager = GameObject.Find("GameManager");
        manager_script = manager.GetComponent<GameManager>();
    }
	
	void Update () {
        RoomChange();
        Vector3 pos;
        pos = manager.transform.position;
        pos.x = transform.position.x - 8;
        pos.y = transform.position.y + 4;
        manager.transform.position = pos;
    }

    void RoomChange()
    {
        Vector3 pos = new Vector3();
        /* pos = transform.position;
         pos.x = GameObject.FindGameObjectWithTag("Player").transform.position.x;
         pos.y = GameObject.FindGameObjectWithTag("Player").transform.position.y;
         transform.position = pos;
         Debug.Log(pos);
         Debug.Log(GameObject.FindGameObjectWithTag("Player").transform.position);*/


        if (transform.position.x + 9.5f < GameObject.FindGameObjectWithTag("Player").transform.position.x)
        {
            pos = transform.position;
            pos.x += 19;
            transform.position = pos;

        }
        if (transform.position.x - 9.5f > GameObject.FindGameObjectWithTag("Player").transform.position.x)
        {
            pos = transform.position;
            pos.x -= 19;
            transform.position = pos;
        }
            if (transform.position.y + 5.7f < GameObject.FindGameObjectWithTag("Player").transform.position.y)
        {
            pos = transform.position;
            pos.y += 11f;
            transform.position = pos;

        }
        if (transform.position.y - 5.7f > GameObject.FindGameObjectWithTag("Player").transform.position.y)
        {
            pos = transform.position;
            pos.y -= 11f;
            transform.position = pos;

        }
        //Debug.Log((GameObject.FindGameObjectWithTag("Player").transform.position.y - (transform.position.y - 5.7f)) + "  " + ((transform.position.y + 5.7f) - GameObject.FindGameObjectWithTag("Player").transform.position.y) + "  " + (GameObject.FindGameObjectWithTag("Player").transform.position.x - (transform.position.x - 9.7f)) + "  " + ((transform.position.x + 9.7f) - GameObject.FindGameObjectWithTag("Player").transform.position.x));
    }

}
