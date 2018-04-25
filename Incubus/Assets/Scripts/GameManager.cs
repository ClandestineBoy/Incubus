using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public bool GameOver;

    public bool healthpack;
    public AudioClip healthNoise;

    public AudioClip hurt;
    public AudioClip music;
    public AudioClip night;

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

    public GameObject health;

    public bool InBed = false;

    void Start()
    {
        GameOver = false;
        muzic = sound.me.PlaySound(night, .1f, 1, true);
         doorsClosed = true;
        tm = GetComponent<TextMesh>();
        bulletDamage = 1;
        playerExists = false;
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (GameOver)
        {
            StartOver();
        }
        //Music();
        Debug.Log(SceneManager.GetActiveScene());
        if (InBed == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                muzic.Stop();
                SceneManager.LoadScene("Floor_1");
                GameObject.Find("Player").transform.position = new Vector3(0, 0, -1);
                InBed = false;
                muzic = sound.me.PlaySound(music, .5f, 1, true);
            }
        }
        if (Input.GetMouseButtonDown(1) && SceneManager.GetActiveScene().buildIndex == 0)
        {

            SceneManager.LoadScene("Room");
            if (playerExists == false)
            {
                playerExists = true;
                Instantiate(player);
            }
        }
        if (SceneManager.GetActiveScene().buildIndex != 0 && SceneManager.GetActiveScene().buildIndex != 4)
        {
            rooms = GameObject.FindGameObjectsWithTag("Room");
        }
        if (enemiesInRoom <= 0)
        {
            float chance = Random.Range(.1f, 1);
            Debug.Log(chance);
            doorsClosed = false;
            for (int i = 0; i < rooms.Length; i++)
            {
                if (rooms[i].GetComponent<Room_Stuff>().inRoom == true && rooms[i].GetComponent<Room_Stuff>().roomStart == false)
                {
                    if (chance >= .75f && rooms[i].GetComponent<Room_Stuff>().defeated == false && rooms[i] != GameObject.Find("Room (1)"))
                    {
                        healthpack = true;
                        sound.me.PlaySound(healthNoise, .5f, 1);
                    }
                    rooms[i].GetComponent<Room_Stuff>().defeated = true;

                }
            }
        }
        if (enemiesInRoom > 0)
        {
            doorsClosed = true;
        }
        if (SceneManager.GetActiveScene().buildIndex == 1)
            tm.text = playerHealth + "";

        if (Input.GetKeyDown(reset))
        {
            StartOver();
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

    AudioSource muzic = new AudioSource();

    public void StartOver()
    {
        SceneManager.LoadScene("Room");
        enemiesInRoom = 0;     
        muzic.Stop();
        muzic = sound.me.PlaySound(night, .5f, 1, true);
        Destroy(GameObject.Find("Player"));

        GameOver = false;
    }

}
