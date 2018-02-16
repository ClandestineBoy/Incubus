using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour {

    public GameObject player;

    
    void Start () {
		
	}
	
	void Update () {
        RoomChange();
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
            pos.y += 12;
            transform.position = pos;

        }
        if (transform.position.y - 5.7f > GameObject.FindGameObjectWithTag("Player").transform.position.y)
        {
            pos = transform.position;
            pos.y -= 12;
            transform.position = pos;

        }
        //Debug.Log((GameObject.FindGameObjectWithTag("Player").transform.position.y - (transform.position.y - 5.7f)) + "  " + ((transform.position.y + 5.7f) - GameObject.FindGameObjectWithTag("Player").transform.position.y) + "  " + (GameObject.FindGameObjectWithTag("Player").transform.position.x - (transform.position.x - 9.7f)) + "  " + ((transform.position.x + 9.7f) - GameObject.FindGameObjectWithTag("Player").transform.position.x));
    }

}
