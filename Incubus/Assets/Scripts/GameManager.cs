using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject player;
    bool playerExists;
    public float bulletDamage = 1; 

	// Use this for initialization
	void Start () {
        playerExists = false;
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
