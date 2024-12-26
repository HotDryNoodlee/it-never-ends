using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class power : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject boundryup;
    public GameObject boundrydown;
    public float upposition;
    public float downposition;
    public Transform powers;
    public Transform enemy1;
    public Transform enemy2;
    //private GameObject cam;
    public Camera cam;
    public float width;
    public GameObject player;
    void Start()
    {
        cam = Camera.main;
        boundryup = GameObject.Find("boundryup");
        boundrydown = GameObject.Find("boundrydown");
        powers = GameObject.Find("power").transform;
        enemy1 = GameObject.Find("enemy1").transform;
        enemy2 = GameObject.Find("enemy2").transform;
        upposition = boundryup.transform.position.y - (boundryup.GetComponent<SpriteRenderer>().bounds.size.y)/2;
        downposition = boundrydown.transform.position.y + (boundrydown.GetComponent<SpriteRenderer>().bounds.size.y)/2;
        float targetx = boundryup.transform.position.x + Random.Range(-30, 30);
        float targety = upposition - Random.Range(2, 8);
        powers.position = new Vector2(targetx, targety);
        width = cam.orthographicSize * cam.aspect;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(upposition + " " + downposition + "\n" + boundryup.transform.position.y + " " + boundrydown.transform.position.y);
        if (powers.position.x < cam.transform.position.x - width)
        {
            float targetx = boundryup.transform.position.x + Random.Range(-10, 10) + width;
            float targety = upposition - Random.Range(2, 8);
            powers.position = new Vector2(targetx, targety);
        }
        if(enemy1.position.x < cam.transform.position.x - width)
        {
            float targetx = boundryup.transform.position.x + Random.Range(4, 6);
            enemy1.position = new Vector2(targetx, enemy1.position.y);
        }
        if (enemy2.position.x < cam.transform.position.x - width)
        {
            float targetx = enemy1.position.x + Random.Range(11, 14);
            enemy2.position = new Vector2(targetx, enemy2.position.y);
        }
    }
}
