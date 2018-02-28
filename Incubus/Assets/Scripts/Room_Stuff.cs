using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_Stuff : MonoBehaviour {

    public float enemies;
    public GameObject manager;
    public bool inRoom;
    GameManager manager_script;
    public bool defeated;
    public bool roomStart;

    // Use this for initialization
    void Start () {
        defeated = false;
        manager = GameObject.Find("GameManager");
        manager_script = manager.GetComponent<GameManager>();
    }
	
	// Update is called once per frame
	void Update () {
        if (manager_script.enemiesInRoom <= 0 && defeated == false && inRoom == true && roomStart == true)
        {
            Debug.Log("Sup nerd");
            manager_script.enemiesInRoom = enemies;
            roomStart = false;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            roomStart = true;
            inRoom = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
    }
    }
