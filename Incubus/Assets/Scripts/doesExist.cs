using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doesExist : MonoBehaviour {
    public GameObject manager;
    GameManager manager_script;
    
    // Use this for initialization
    void Start () {
        manager = GameObject.Find("GameManager");
        manager_script = manager.GetComponent<GameManager>();
    }
	
	// Update is called once per frame
	void Update () {
		if(manager_script.doorsClosed == false)
        {
            gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        if (manager_script.doorsClosed == true)
        {
            gameObject.GetComponent<Renderer>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
