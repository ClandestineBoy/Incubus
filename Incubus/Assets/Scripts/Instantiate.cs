﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Instantiate : MonoBehaviour {

    public GameObject player;
    bool playerExists = false;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(1) && SceneManager.GetActiveScene().buildIndex == 0)
        {
            SceneManager.LoadScene("Floor_1");
            if (playerExists == false)
            {
                playerExists = true;
                Instantiate(player);
            }
            
        }
	}
}
