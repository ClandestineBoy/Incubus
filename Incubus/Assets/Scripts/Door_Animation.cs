using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Animation : MonoBehaviour {
    public GameObject manager;
    GameManager manager_script;

    public Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = this.GetComponent<Animator>();
        manager = GameObject.Find("GameManager");
        manager_script = manager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (manager_script.doorsClosed == false)
        {
            anim.SetInteger("Room_State", 0);
        }
        if (manager_script.doorsClosed == true)
        {
            anim.SetInteger("Room_State", 1);
        }
    }
}
