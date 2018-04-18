using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim_Object : MonoBehaviour {
    public GameObject player;
    Movement_Controller player_script;

    float RotateSpeed = 5f;
    float Radius = 1;

    Vector2 center;
    float angle;

	void Start () {
        DontDestroyOnLoad(gameObject);
        player = GameObject.Find("Player");
        player_script = player.GetComponent<Movement_Controller>();
        center = transform.position;
	}

	void Update () {
        angle += RotateSpeed * Time.deltaTime;

        var offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * Radius;
        transform.position = center + offset;
	}
}
