using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public AudioClip hurt;

    public KeyCode reset;
    public GameObject player;
    bool playerExists;
    public float bulletDamage;
    public float playerHealth;
    public float enemiesInRoom;
    public bool doorsClosed;
    TextMesh tm;
    public Vector2 playerPos;

    public GameObject[] rooms;

	// Use this for initialization
	void Start () {
        
        doorsClosed = true;
        tm = GetComponent<TextMesh>();
        bulletDamage = 1;
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
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            rooms = GameObject.FindGameObjectsWithTag("Room");
        }
        if (enemiesInRoom <= 0)
        {
            doorsClosed = false;
            for(int i = 0; i < rooms.Length; i++)
            {
                if (rooms[i].GetComponent<Room_Stuff>().inRoom == true && rooms[i].GetComponent<Room_Stuff>().roomStart == false)
                {
                    rooms[i].GetComponent<Room_Stuff>().defeated = true;
                   
                }
            }
        }
        if (enemiesInRoom > 0)
        {
            doorsClosed = true;
        }
        if (SceneManager.GetActiveScene().buildIndex != 0)
        tm.text = playerHealth + "";

        if (Input.GetKeyDown(reset))
        {
            SceneManager.LoadScene(1);
            GameObject.Find("Player").transform.position = new Vector3(0, 0, 0);
        }
    }

    public void TakeDamage(float damage)
    {
        playerHealth -= damage;
        sound.me.PlaySound(hurt, 1f, Random.Range(.5f, 1f));
    }
    public void UpBulletDamage(float dmg)
    {
        bulletDamage += dmg;
    }
}
