using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject End;
    public GameObject mouseSignal;

    public bool GameOver;
    public bool GameWin;
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
        GameWin = false;
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
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (GameWin == false)
            {
                Debug.Log("end hidden");
                GameObject.FindGameObjectWithTag("end").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.FindGameObjectWithTag("end").GetComponent<Animator>().enabled = false;
            }
        }
        if (GameOver)
        {
            StartOver();
        }
        //Music();
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            if (InBed == true)
            {
                GameObject.FindGameObjectWithTag("mouse signal").GetComponent<SpriteRenderer>().enabled = true;
                if (Input.GetMouseButtonDown(0))
                {
                    muzic.Stop();
                GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(0, 0, -1);
                InBed = false;
                muzic = sound.me.PlaySound(music, .5f, 1, true);
                SceneManager.LoadScene("Floor_1");     
                }
            }
            if (InBed == false)
            {
                GameObject.FindGameObjectWithTag("mouse signal").GetComponent<SpriteRenderer>().enabled = false;
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
            int check = 0;
            float chance = Random.Range(.1f, 1);
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
                if (!rooms[i].GetComponent<Room_Stuff>().defeated)
                {
                    check += 1;
                }
            }
            if(check <= 0)
            {
                GameWin = true;
            }
        }
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (GameObject.Find("Room (1)").GetComponent<Room_Stuff>().inRoom == true && GameWin)
            {
                GameObject.FindGameObjectWithTag("end").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.FindGameObjectWithTag("end").GetComponent<Animator>().SetInteger("Win", 1);
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
       
        enemiesInRoom = 0;     
        muzic.Stop();
        muzic = sound.me.PlaySound(night, .5f, 1, true);
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        GameOver = false;
        SceneManager.LoadScene("Room");
        Instantiate(player);
    }

}
